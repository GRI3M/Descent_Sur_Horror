using UnityEngine;
using StarterAssets;
using Unity.VisualScripting;

namespace ItemScripts.WeaponScripts.GunScripts
{
    public class EquippedWeapon : MonoBehaviour
    {
        [SerializeField] public GunSO gunSO;
            

        [Header("Plugins")]
        
        [SerializeField] public Animator gunAnimator;
        StarterAssetsInputs starterAssetsInputs;
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
        }

        void Update()
        {
            timeSinceLastShot += Time.deltaTime;
            Damage();
        }

        void Damage()
        {
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
                
            }//When other types of weapons are created, weaponSO will be removed and replaced with Utility and Melee weapons
        }
    }
}
