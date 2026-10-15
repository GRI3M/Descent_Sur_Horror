using UnityEngine;
using ItemScripts;

namespace ItemScripts.WeaponScripts.GunScripts.SniperScripts
{
    public class Sniper : Guns
    {
        public enum SniperTypes
        {
            Lightweight,
            FastTrigger,
            Barret50Calibur,
            AWP,
        }

        public int SniperType;
        public bool rechamber;
        public Sniper()
        {
            weaponType = (int)GunTypes.Sniper;
            
        }
        
        
        
    }
}
