using UnityEngine;
using ItemScripts;
using ItemScripts.AmmoScript;

namespace ItemScripts.AmmoScript
{
    [CreateAssetMenu(fileName = "AmmoSO", menuName = "Scriptable Objects/AmmoSO")]
    public class AmmoSO : ItemSO
    {
        [Header("Ammo Identification")]
        public AmmoTypes ammoType;

        [Header("Ammo Attributes")]
        public int maxAmmo;
        public float dropChance;



        protected virtual void OnEnable()
        {
            itemType = ItemTypes.Ammo;
            isStackable = true;
        }
    }
}
