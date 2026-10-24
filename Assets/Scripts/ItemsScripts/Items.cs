using Unity.VisualScripting;
using UnityEngine;

namespace ItemScripts
{
    public class Items : MonoBehaviour
    {
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
