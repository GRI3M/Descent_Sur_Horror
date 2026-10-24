using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.ShotgunScripts
{
    public class Shotgun : Guns
    {
        public enum ShotgunTypes
        {
            DoubleBarrel,
            PumpShotgun,
            Automatic,
            Assult,
            SawedOff,
        }

        public int ShotgunType;

    }
    
}
