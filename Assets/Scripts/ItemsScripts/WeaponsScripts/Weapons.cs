using UnityEngine;


namespace ItemScripts.WeaponScripts
{
    public class Weapons : Items
    {
        [SerializeField] public int weaponType;
        [SerializeField] public float weaponDamage;
        public enum WeaponTypes
        {
            Gun,
            Melee,
        }
    }
}
