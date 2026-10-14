using UnityEngine;
using Player;
using StarterAssets;

namespace ItemScripts.WeaponScripts.GunScripts.PistolScripts
{

    public class Pistol : Guns
    {
        public Pistol()
        {
            weaponDamage = 34f;
            itemType = (int)Items.ItemTypes.Weapon;
            weaponType = (int)Weapons.WeaponTypes.Gun;
            gunType = (int)Guns.GunTypes.Pistol;
        }

        
    }
}
