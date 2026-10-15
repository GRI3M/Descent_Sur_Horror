using UnityEngine;


namespace ItemScripts.WeaponScripts
{
    public class Weapons : Items
    {
        [Header("Weapon Attributes")]
        [SerializeField] public int weaponType;
        [SerializeField] public float weaponDamage;
        public enum WeaponTypes
        {
            Gun,
            Melee,
        }

        public Weapons()
        {
            itemType = (int) itemTypes.Weapon;
        }
    }
}
