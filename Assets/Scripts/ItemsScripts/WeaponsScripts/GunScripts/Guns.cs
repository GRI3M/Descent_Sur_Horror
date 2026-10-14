using UnityEngine;
using StarterAssets;
using Enemy;

namespace ItemScripts.WeaponScripts.GunScripts
{
    public class Guns : Weapons
    {
        
        [SerializeField] public int capacity;
        [SerializeField] public float reloadSpeed;
        [SerializeField] public float fireRate;
        [SerializeField] public bool automatic = false;
        [SerializeField] public int gunType;
        public ParticleSystem muzzleFlash;
        
        StarterAssetsInputs starterAssetsInputs;


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
            
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                EnemyHealthManager enemyHealth = hit.collider.GetComponent<EnemyHealthManager>();
                enemyHealth?.TakeDamage(weaponDamage);
            }
            
            starterAssetsInputs.shoot = false;
        }

    }
}
