using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.SniperScripts.Barret50CaliburScript
{
    public class Barret50Calibur : Sniper
    {
        public Barret50Calibur()
        {
            itemName = "Barret 50 Calibur";
            sniperType = (int) SniperTypes.Barret50Calibur;

            rechamber = false;
        }
    }
}