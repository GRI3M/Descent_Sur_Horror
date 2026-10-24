using UnityEngine;
using StarterAssets;

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
            Damage();
        }

        void Damage()
        {
            if(!starterAssetsInputs.shoot) return;

            equippedGun.Shoot(gunSO);
            gunAnimator.Play(SHOOT_STR, 0, 0f);            
            starterAssetsInputs.ShootInput(false);
        }

    }
}
