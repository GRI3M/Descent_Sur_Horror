using Unity.VisualScripting;
using UnityEngine;

namespace ItemScripts
{
    public class Items : MonoBehaviour
    {
        public ItemSO itemSO;

        public InventoryTracker inventoryTracker;

        public class InventoryTracker
        {
            public int inventoryRow;
            public int inventoryColumn;

            public InventoryTracker(int ir, int ic)
            {
                inventoryRow = ir;
                inventoryColumn = ic;
            }
        }
    }

    /// <summary>
    /// Types of items that can be assigned to an item.
    /// </summary>
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
