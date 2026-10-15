using UnityEngine;

namespace ItemScripts
{
    public class Items : MonoBehaviour
    {
        public int itemType;

        public enum itemTypes
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
