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

        Weapons equippedWeapon;
        Guns equippedGun;
        GunSO equippedGunSO;
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

            if(currentAmmo > equippedGunSO.capacity) currentAmmo = equippedGunSO.capacity;

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

            if(timeSinceLastShot >= equippedGunSO.fireRate && currentAmmo > 0)
            {
                equippedGun.Shoot(equippedGunSO);
                gunAnimator.Play(SHOOT_STR, 0, 0f);
                timeSinceLastShot = 0f;
                UpdateAmmo(-1);
            }
            
            if(!equippedGunSO.automatic) starterAssetsInputs.ShootInput(false);
        }


        /// <summary>
        /// Handles switching from one weapon to the next.
        /// </summary>
        /// <param name="weaponSO">Weapon being switched to</param>
        /// 
        /// Switch this to have the weaponSO/GunSO tied directly to the weapon 
        /// instead of a pickup because I want this weapon to switch based upon 
        /// pressing 1, 2, 3, or 4 or by pressing the last weapon button
        public void SwitchWeapon(WeaponSO weaponSO)
        {
            if(equippedGun) Destroy(equippedGun.gameObject);
            
            if(weaponSO.weaponType == WeaponTypes.Gun) 
            {
                Guns newGun = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Guns>();
                equippedGun = newGun;
                equippedGunSO = (GunSO) weaponSO;
                fps.ChangeRotationSpeed(equippedGunSO.standardSensitivity); 
                starterAssetsInputs.zoom = false;
                UpdateAmmo(equippedGunSO.capacity);
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
            if(!equippedGunSO.CanZoom) return;

            if (starterAssetsInputs.zoom)
            {
                playerCamera.m_Lens.FieldOfView = equippedGunSO.ZoomAmount;
                scopeVignette.SetActive(true);
                fps.ChangeRotationSpeed(equippedGunSO.zoomSensitivity);
                weaponModel.enabled = false;
            }
            else
            {
                playerCamera.m_Lens.FieldOfView = defaultZoom;
                scopeVignette.SetActive(false);
                fps.ChangeRotationSpeed(equippedGunSO.standardSensitivity);
                weaponModel.enabled = true;
            }
        }
    }
}
