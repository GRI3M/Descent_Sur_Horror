using Unity.VisualScripting;
using UnityEngine;

namespace ItemScripts
{
    public class Items : MonoBehaviour
    {
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
}
