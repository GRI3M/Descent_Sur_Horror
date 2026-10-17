using System;
using Unity.VisualScripting;
using UnityEngine;


namespace ItemScripts.WeaponScripts
{
    public class Weapons : Items
    {
        [Header("Weapon Attributes")]
        [SerializeField] public int weaponType;
        [SerializeField] public float weaponDamage;
        [SerializeField] public float critModifier;
        

        public enum WeaponTypes
        {
            Gun,
            Melee,
        }

        public Weapons()
        {
            itemType = (int) ItemTypes.Weapon;
            equipable = true;
        }
    }
}
