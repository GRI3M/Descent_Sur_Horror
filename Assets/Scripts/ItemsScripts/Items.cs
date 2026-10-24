using Unity.VisualScripting;
using UnityEngine;

namespace ItemScripts
{
    public class Items : MonoBehaviour
    {
        [Header("Item Attributes")]
        [SerializeField] public string itemName = "Empty";
        [SerializeField] public int itemType = (int) Items.ItemTypes.Empty;
        [SerializeField] public bool equipable = false;
        [SerializeField] public float movementSpeedModifier = 1.5f;

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

        public class EmptyItem : Items
        {
            public EmptyItem()
            {
                itemName = "Empty";
                itemType = (int) Items.ItemTypes.Empty;
                equipable = true;
                movementSpeedModifier = 1.5f;
            }
        }
    }
}
