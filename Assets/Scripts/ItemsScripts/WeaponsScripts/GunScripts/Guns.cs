using UnityEngine;
using StarterAssets;
using Enemy; 

namespace ItemScripts.WeaponScripts.GunScripts
{
    public class Guns : Weapons
    {
        public enum GunTypes
        {
            Pistol,
            Shotgun,
            Rifle,
            Sniper,
            SMG,
            Handcannon,
            GrenadeLauncher,
        }

        [SerializeField] public ParticleSystem muzzleFlash;

        public void Shoot(GunSO gunSO)
        {
            

            muzzleFlash.Play();
            
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Instantiate(gunSO.hitVFX, hit.point, Quaternion.identity);
                

                EnemyHealthManager enemyHealth = hit.collider.GetComponent<EnemyHealthManager>();
                enemyHealth?.TakeDamage(gunSO.weaponDamage);
            }
            
        }
    }
}
