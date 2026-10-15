using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.SMGScripts
{
    public class SMG : Guns
    {
        public enum SMGTypes
        {
            MAC10,
            MP9,
            UMP,
            MP5,
        }

        public int SMGType;

        public SMG()
        {
            gunType = (int) GunTypes.SMG;
        }
    }
    
}
