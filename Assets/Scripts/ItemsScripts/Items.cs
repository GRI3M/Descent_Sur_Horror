using UnityEngine;

namespace ItemScripts
{
    public class Items : MonoBehaviour
    {
        public int itemType;

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
