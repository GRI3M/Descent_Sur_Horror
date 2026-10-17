using UnityEngine;
using Player;
using StarterAssets;

namespace ItemScripts.WeaponScripts.GunScripts.PistolScripts
{

    public class Pistol : Guns
    {

        public enum PistolTypes
        {
            Glock19,
            USP,
            ArmyRevolver,
            FiveSeven,
            M1911,
            Tech9,
        }
        [Header("Pistol Attributes")]
        public int pistolType;

        public Pistol()
        {
            gunType = (int)Guns.GunTypes.Pistol;
        }

        
    }
}
