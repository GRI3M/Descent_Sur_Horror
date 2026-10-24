using UnityEngine;
using Player;
using StarterAssets;

namespace ItemScripts.WeaponScripts.GunScripts.PistolScripts
{

    public class Pistol : Guns
    {

        public enum PistolTypes
        {
            Glock18,
            USP,
            ArmyRevolver,
            FiveSeven,
            M1911,
            Tech9,
        }
        [Header("Pistol Attributes")]
        public int pistolType;


        
    }
}
