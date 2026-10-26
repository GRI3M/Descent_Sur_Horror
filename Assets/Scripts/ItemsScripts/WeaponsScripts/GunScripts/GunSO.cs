using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "GunSO", menuName = "Scriptable Objects/GunSO")]
    public class GunSO : WeaponSO
    {  
        [Header("Gun Attributes")]
        public int capacity;
        public int currentAmmo;
        public float reloadSpeed;
        public float fireRate;
        public bool automatic = false;
        public int gunType;
        public bool CanZoom;
        public float ZoomAmount;
        public float standardSensitivity = 1;
        public float zoomSensitivity;
        public float accuracy;
        public float accuracyUnscoped;

        public GameObject hitVFX;

        protected override void OnEnable()
        {
            base.OnEnable();
            weaponType = (int)Weapons.WeaponTypes.Gun;
        }
    }
}
