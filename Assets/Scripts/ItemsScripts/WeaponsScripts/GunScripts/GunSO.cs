using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "GunSO", menuName = "Scriptable Objects/GunSO")]
    public class GunSO : WeaponSO
    {  
        [Header("Gun Attributes")]
        public int capacity;
        public float reloadSpeed;
        public float fireRate;
        public bool automatic = false;
        public GunTypes gunType;
        public bool CanZoom;
        public float ZoomAmount;
        public float standardSensitivity = 1;
        public float zoomSensitivity;
        public float accuracy;
        public float accuracyUnscoped;

        [Header("Pluggins")]
        public GameObject hitVFX;

        /// <summary>
        /// Sets values inherited by the gun class.
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            weaponType = WeaponTypes.Gun;
        }
    }
}
