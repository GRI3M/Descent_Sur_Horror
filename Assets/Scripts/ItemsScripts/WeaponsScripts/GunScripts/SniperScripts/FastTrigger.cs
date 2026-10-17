using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.SniperScripts.FastTriggerScript
{
    public class FastTrigger : Sniper
    {
        public FastTrigger()
        {
            itemName =  "Fast Trigger";
            sniperType = (int) SniperTypes.FastTrigger;

            rechamber = false;
        }
    }
}
