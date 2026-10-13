using UnityEngine;
using StarterAssets;

namespace ItemScripts.WeaponScripts.GunScripts
{
    public class Guns : Weapons
    {
        
        [SerializeField] public int capacity;
        [SerializeField] public float reloadSpeed;
        [SerializeField] public float fireRate;
        [SerializeField] public bool automatic = false;
        [SerializeField] public int WeaponType;

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
            shootGun();
        }

        public void shootGun()
        {
            if(starterAssetsInputs.shoot)
            {
                RaycastHit hit;

                if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
                {
                    Debug.Log(hit.collider.name);
                    starterAssetsInputs.shoot = false;
                }
            }
        }

    }
}
