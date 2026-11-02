using System.ComponentModel;
using ItemScripts;
using UnityEngine;

namespace ItemScripts.WeaponScripts
{
    [CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
    public class WeaponSO : ItemSO
    {
        [Header("Weapon Attributes")]
        public GameObject weaponPrefab;
        public int weaponType;
        public float weaponDamage;
        public float critModifer;

        /// <summary>
        /// Sets values inherited by the item class.
        /// </summary>
        protected virtual void OnEnable()
        {
            itemType = (int) Items.ItemTypes.Weapon;
            equipable = true;
        }
    }
}
