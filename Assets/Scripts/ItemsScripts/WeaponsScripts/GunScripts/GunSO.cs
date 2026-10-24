using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts
{
    [CreateAssetMenu(fileName = "GunSO", menuName = "Scriptable Objects/GunSO")]
    public class GunSO : ScriptableObject
    {
        public int capacity;
        public int currentAmmo;
        public float reloadSpeed;
        public float fireRate;
        public bool automatic = false;
        public int gunType;
        public float accuracy;
        public float accuracyUnscoped;

        public GameObject hitVFX;
    }
    
}
