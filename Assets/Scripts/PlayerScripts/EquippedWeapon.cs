using UnityEngine;
using StarterAssets;
using Unity.VisualScripting;
using Unity.Cinemachine;
using TMPro;

namespace ItemScripts.WeaponScripts.GunScripts
{
    public class EquippedWeapon : MonoBehaviour
    {

        [Header("Plugins")]
        
        [SerializeField] public GunSO startingGunSO;
        [SerializeField] public Animator gunAnimator;
        StarterAssetsInputs starterAssetsInputs;
        [SerializeField] public CinemachineVirtualCamera playerCamera;
        [SerializeField] public GameObject scopeVignette;
        [SerializeField] public TMP_Text ammo_text;
        FirstPersonController fps;

        [Header("Currently Equipped Weapon")]
        Guns equippedGun;
        GunSO currentGunSO;
        public MeshRenderer weaponModel;

        [Header("Weapon Values")]
        float timeSinceLastShot = 0f;
        int currentAmmo;
        float defaultZoom;

        [Header("Constants")]
        const string SHOOT_STR = "ShootWeapon"; 

        void Start()
        {
            SwitchWeapon(startingGunSO);
        }

        void Awake()
        {
            starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
            gunAnimator = GetComponent<Animator>();
            defaultZoom = playerCamera.m_Lens.FieldOfView;
            fps = GetComponentInParent<FirstPersonController>();
            
        }

        void Update()
        {
            HandleShoot();
            HandleZoom();
        }

        /// <summary>
        /// Updates the amount of ammo in a weapon.
        /// </summary>
        /// <param name="amount">Ammo being used/replenished</param>
        public void UpdateAmmo(int amount)
        {
            currentAmmo += amount;

            if(currentAmmo > currentGunSO.capacity) currentAmmo = currentGunSO.capacity;

            equippedGun.ammoCount = currentAmmo;

            ammo_text.text = currentAmmo.ToString("D2");
        }

        /// <summary>
        /// Handles the weapon firing.
        /// </summary>
        void HandleShoot()
        {
            timeSinceLastShot += Time.deltaTime;

            if(!starterAssetsInputs.shoot) return;

            if(timeSinceLastShot >= currentGunSO.fireRate && currentAmmo > 0)
            {
                equippedGun.Shoot(currentGunSO);
                gunAnimator.Play(SHOOT_STR, 0, 0f);
                timeSinceLastShot = 0f;
                UpdateAmmo(-1);
            }
            
            if(!currentGunSO.automatic) starterAssetsInputs.ShootInput(false);
        }


        /// <summary>
        /// Handles switching from one weapon to the next.
        /// </summary>
        /// <param name="weaponSO">Weapon being switched to.</param>
        public void SwitchWeapon(WeaponSO weaponSO)
        {
            if(equippedGun) Destroy(equippedGun.gameObject);
            
            if(weaponSO.weaponType == (int) Weapons.WeaponTypes.Gun) 
            {
                Guns newGun = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Guns>();
                equippedGun = newGun;
                currentGunSO = (GunSO) weaponSO;
                fps.ChangeRotationSpeed(currentGunSO.standardSensitivity); 
                starterAssetsInputs.zoom = false;
                UpdateAmmo(currentGunSO.capacity);
                this.weaponModel = newGun.weaponModel;
            }//When other types of weapons are created, weaponSO will be removed and replaced with Utility and Melee weapons
        }

        /// <summary>
        /// Handles a weapon zooming in and out, if equipped gun has a sniper zoom.
        /// Might update this to slow the player down if they are zooming in with a 
        /// heavier sniper rifle.
        /// </summary>
        void HandleZoom()
        {
            if(!currentGunSO.CanZoom) return;

            if (starterAssetsInputs.zoom)
            {
                playerCamera.m_Lens.FieldOfView = currentGunSO.ZoomAmount;
                scopeVignette.SetActive(true);
                fps.ChangeRotationSpeed(currentGunSO.zoomSensitivity);
                weaponModel.enabled = false;
            }
            else
            {
                playerCamera.m_Lens.FieldOfView = defaultZoom;
                scopeVignette.SetActive(false);
                fps.ChangeRotationSpeed(currentGunSO.standardSensitivity);
                weaponModel.enabled = true;
            }
        }
    }
}
