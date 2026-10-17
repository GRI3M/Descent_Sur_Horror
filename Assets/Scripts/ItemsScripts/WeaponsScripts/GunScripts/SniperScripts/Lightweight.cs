using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.SniperScripts
{
    public class Lightweight : Sniper
    {
        public Lightweight()
        {
            itemName = "Lightweight";
            sniperType = (int) SniperTypes.Lightweight;

            rechamber = true;
        }
    }
}
