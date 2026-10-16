using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.GrenadeLauncherScripts
{
    public class GrenadeLauncher : Guns
    {
        public enum GrenadeLauncherTypes
        {
            SingleShot,
            RevolvingBarrels,
        }

        public int grenadeLauncherType;

        public GrenadeLauncher()
        {
            gunType = (int) GunTypes.GrenadeLauncher;
        }
    }
    
}
