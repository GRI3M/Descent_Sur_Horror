using UnityEngine;
using StarterAssets;
using Unity.VisualScripting;
using Unity.Cinemachine;

namespace ItemScripts.WeaponScripts.GunScripts
{
    public class EquippedWeapon : MonoBehaviour
    {
        [SerializeField] public GunSO gunSO;
        
        float defaultZoom;
        public GameObject weaponModel;

        [Header("Plugins")]
        
        [SerializeField] public Animator gunAnimator;
        StarterAssetsInputs starterAssetsInputs;
        [SerializeField] public CinemachineVirtualCamera playerCamera;

        [SerializeField] public GameObject scopeVignette;
        FirstPersonController fps;
        Guns equippedGun;
        const string SHOOT_STR = "ShootWeapon"; 
        float timeSinceLastShot = 0f;

        void Start()
        {
            equippedGun = GetComponentInChildren<Guns>();
        }

        void Awake()
        {
            starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
            gunAnimator = GetComponent<Animator>();
            defaultZoom = playerCamera.m_Lens.FieldOfView;
            fps = GetComponentInParent<FirstPersonController>();
            fps.ChangeRotationSpeed(gunSO.standardSensitivity);
        }

        void Update()
        {
            HandleShoot();
            HandleZoom();
        }

        void HandleShoot()
        {
            timeSinceLastShot += Time.deltaTime;

            if(!starterAssetsInputs.shoot) return;

            if(timeSinceLastShot >= gunSO.fireRate)
            {
                equippedGun.Shoot(gunSO);
                gunAnimator.Play(SHOOT_STR, 0, 0f);
                timeSinceLastShot = 0f;
            }
            if(!gunSO.automatic) starterAssetsInputs.ShootInput(false);
        }

        public void SwitchWeapon(WeaponSO weaponSO)
        {
            if(equippedGun) Destroy(equippedGun.gameObject);
            
            if(weaponSO.weaponType == (int) Weapons.WeaponTypes.Gun) 
            {
                Guns newGun = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Guns>();
                equippedGun = newGun;
                gunSO = (GunSO) weaponSO;
                fps.ChangeRotationSpeed(gunSO.standardSensitivity); 
            }//When other types of weapons are created, weaponSO will be removed and replaced with Utility and Melee weapons
        }

        public void HandleZoom()
        {
            if(!gunSO.CanZoom) return;

            if (starterAssetsInputs.zoom)
            {
                playerCamera.m_Lens.FieldOfView = gunSO.ZoomAmount;
                scopeVignette.SetActive(true);
                fps.ChangeRotationSpeed(gunSO.zoomSensitivity);
            }
            else
            {
                playerCamera.m_Lens.FieldOfView = defaultZoom;
                scopeVignette.SetActive(false);
                fps.ChangeRotationSpeed(gunSO.standardSensitivity);
            }
        }
    }
}
