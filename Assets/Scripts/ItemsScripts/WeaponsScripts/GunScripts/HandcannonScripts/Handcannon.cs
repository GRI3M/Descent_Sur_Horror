using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.HandcannonScript
{
    public class Handcannon : Guns
    {
        public enum HandcannonTypes
        {
            MagnumRevolver,
            Deagle,
            OldWestern,
        }

        public int handcannonType;

        Handcannon()
        {
            gunType = (int) GunTypes.Handcannon;
        }
    }
    
}
