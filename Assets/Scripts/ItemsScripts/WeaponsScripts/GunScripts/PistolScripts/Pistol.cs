using UnityEngine;
using Player;
using StarterAssets;

namespace ItemScripts.WeaponScripts.GunScripts.PistolScripts
{

    public class Pistol : Guns
    {

        public enum pistolTypes
        {
            Glock19,
            USP,
            ArmyRevolver,
            FiveSeven,
            M1911,
            Tech9,
        }
        public int pistolType;

        public Pistol()
        {
            weaponDamage = 34f;
            gunType = (int)Guns.GunTypes.Pistol;
        }

        
    }
}
