using UnityEngine;
using StarterAssets;
using Enemy;
using Unity.Mathematics;

namespace ItemScripts.WeaponScripts.GunScripts
{
    public class Guns : Weapons
    {
        
        [SerializeField] public int capacity;
        [SerializeField] public float reloadSpeed;
        [SerializeField] public float fireRate;
        [SerializeField] public bool automatic = false;
        [SerializeField] public int gunType;
        [SerializeField] public ParticleSystem muzzleFlash;
        [SerializeField] public Animator gunAnimator;
        [SerializeField] public GameObject hitVFX;
        StarterAssetsInputs starterAssetsInputs;
        const string SHOOT_STR = "ShootWeapon"; 


        public enum GunTypes
        {
            Pistol,
            Shotgun,
            Rifle,
            Sniper,
            SMG,
            Magnum,
            GrenadeLauncher,
        }


        void Awake()
        {
            starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        }

        void Update()
        {
            Damage();
        }

        void Damage()
        {
            

            if(!starterAssetsInputs.shoot) return;

            muzzleFlash.Play();
            gunAnimator.Play(SHOOT_STR, 0, 0f);
            
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Instantiate(hitVFX, hit.point, quaternion.identity);
                

                EnemyHealthManager enemyHealth = hit.collider.GetComponent<EnemyHealthManager>();
                enemyHealth?.TakeDamage(weaponDamage);
            }
            
            starterAssetsInputs.shoot = false;
        }

    }
}
