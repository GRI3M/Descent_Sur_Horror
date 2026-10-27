using UnityEngine;
using StarterAssets;
using Enemy;
using Unity.VisualScripting;
using Unity.Cinemachine;

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


        [SerializeField] public int ammoCount;
        [SerializeField] public ParticleSystem muzzleFlash;
        [SerializeField] public LayerMask layerMask;
        [SerializeField] public CinemachineImpulseSource impulseSource;


        public void Shoot(GunSO gunSO)
        {
            

            muzzleFlash.Play();
            impulseSource.GenerateImpulse();
            
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
            {
                Instantiate(gunSO.hitVFX, hit.point, Quaternion.identity);
                

                EnemyHealthManager enemyHealth = hit.collider.GetComponent<EnemyHealthManager>();
                enemyHealth?.TakeDamage(gunSO.weaponDamage);
            }
            
        }
    }
}
