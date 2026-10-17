using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.PistolScripts.ArmyRevolverScript
{
    public class ArmyRevolver : Pistol
    {
        public ArmyRevolver()
        {
            itemName = "Army Revolver";
            pistolType = (int) PistolTypes.ArmyRevolver;
        }
    }
}
