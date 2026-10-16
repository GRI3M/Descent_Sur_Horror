using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.RifleScripts
{
    public class Rifle : Guns
    {
        public enum RifleTypes
        {
            M1Grande,
            MK14,
            M4,
            AK47,
        }

        public int rifleType;

        public Rifle()
        {
            gunType = (int) GunTypes.Rifle;
        }
    }
}
