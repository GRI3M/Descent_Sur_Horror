using TMPro;
using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.PistolScripts.Glock19
{
    public class Glock19 : Pistol
    {
        



        public Glock19()
        {
            itemName = "Glock-19";
            pistolType = (int) PistolTypes.Glock19;

            weaponDamage = 22f;
            capacity = 20;

            movementSpeedModifier = 1.1f;
            //reloadSpeed = fast;
            //fireRate = fast;
            critModifier = 2f;
            //accuracy = moderate
            //accuracyUnscoped = moderate
        }
    }
    
}
