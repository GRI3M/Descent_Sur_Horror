using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.PistolScripts
{
    [CreateAssetMenu(fileName = "PistolSO", menuName = "Scriptable Objects/PistolSO")]
    public class PistolSO : GunSO
    {
        [Header("Pistol Attributes")]
        public int pistolType;

        //This might be removed and replaced with basic script.
        public PistolUpgradeSO pistolUpgradeSO;

        /// <summary>
        /// Automatically assign gun type
        /// </summary>
        protected override void OnEnable() 
        {
            base.OnEnable();
            gunType = (int) Guns.GunTypes.Pistol;
        }
    }
}
