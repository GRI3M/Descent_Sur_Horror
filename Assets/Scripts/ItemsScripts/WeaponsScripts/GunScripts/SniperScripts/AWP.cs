using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.SniperScripts
{
    public class AWP : Sniper
    {
        public AWP()
        {
            itemName = "AWP";
            sniperType = (int) SniperTypes.AWP;

            capacity = 5;
            weaponDamage = 160.5f;

            reloadSpeed = 3.5f; //slow
            fireRate = 1.57f;  //slow
            rechamber = true;  //slow
            accuracy = 1f;
            accuracyUnscoped = .1f;
        }
    }
}
