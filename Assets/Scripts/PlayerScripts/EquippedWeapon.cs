using UnityEngine;
using StarterAssets;
using Unity.VisualScripting;
using Unity.Cinemachine;
using TMPro;

namespace ItemScripts.WeaponScripts.GunScripts
{
    public class EquippedWeapon : MonoBehaviour
    {
        [SerializeField] public GunSO startingGunSO;

        GunSO currentGunSO;
        
        float defaultZoom;
        public GameObject weaponModel;

        [Header("Plugins")]
        
        [SerializeField] public Animator gunAnimator;
        StarterAssetsInputs starterAssetsInputs;
        [SerializeField] public CinemachineVirtualCamera playerCamera;

        [SerializeField] public GameObject scopeVignette;
        [SerializeField] public TMP_Text ammo_text;
        FirstPersonController fps;
        Guns equippedGun;
        const string SHOOT_STR = "ShootWeapon"; 
        float timeSinceLastShot = 0f;
        int currentAmmo;

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

        public void UpdateAmmo(int amount)
        {
            currentAmmo += amount;

            if(currentAmmo > currentGunSO.capacity) currentAmmo = currentGunSO.capacity;

            ammo_text.text = currentAmmo.ToString("D2");
        }

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

        public void SwitchWeapon(WeaponSO weaponSO)
        {
            if(equippedGun) Destroy(equippedGun.gameObject);
            
            if(weaponSO.weaponType == (int) Weapons.WeaponTypes.Gun) 
            {
                Guns newGun = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Guns>();
                equippedGun = newGun;
                currentGunSO = (GunSO) weaponSO;
                fps.ChangeRotationSpeed(currentGunSO.standardSensitivity); 
                UpdateAmmo(currentGunSO.capacity);

            }//When other types of weapons are created, weaponSO will be removed and replaced with Utility and Melee weapons
        }

        public void HandleZoom()
        {
            if(!currentGunSO.CanZoom) return;

            if (starterAssetsInputs.zoom)
            {
                playerCamera.m_Lens.FieldOfView = currentGunSO.ZoomAmount;
                scopeVignette.SetActive(true);
                fps.ChangeRotationSpeed(currentGunSO.zoomSensitivity);
            }
            else
            {
                playerCamera.m_Lens.FieldOfView = defaultZoom;
                scopeVignette.SetActive(false);
                fps.ChangeRotationSpeed(currentGunSO.standardSensitivity);
            }
        }
    }
}
