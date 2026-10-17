using Unity.VisualScripting;
using UnityEngine;

namespace ItemScripts
{
    public class Items : MonoBehaviour
    {
        [Header("Item Attributes")]
        [SerializeField] public string itemName;
        [SerializeField] public int itemType;
        [SerializeField] public bool equipable;
        [SerializeField] public float movementSpeedModifier;

        public enum ItemTypes
        {
            Blocked,
            Empty,
            Material,
            Weapon,
            Ammo,
            Healing,
            Utility,
        }
    }
}
