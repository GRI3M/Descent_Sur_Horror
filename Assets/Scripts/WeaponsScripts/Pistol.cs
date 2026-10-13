using UnityEngine;
using Player;

namespace Weapons
{

    public class Pistol : MonoBehaviour
    {
        public int pistolCapacity = 15;

        public int currentAmmo = pistolCapacity;

        public void ShootPistol(FirstPersonController player)
        {
            if (currentAmmo > 0)
            {
                currentAmmo--;
                Debug.Log("Pistol shot fired! Remaining ammo: " + currentAmmo);
            }
            else
            {
                Debug.Log("No ammo left! Reload the pistol.");
            }
        }

        public void ReloadPistol(int currentAmmo,int pistolCapacity)
        {
            
        }
        
    }
}
