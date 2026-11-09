using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.HandcannonScript
{
    [CreateAssetMenu(fileName = "HandcannonSO", menuName = "Scriptable Objects/HandcannonSO")]
    public class HandcannonSO : GunSO
    {
        public HandcannonTypes handcannonType;

        /// <summary>
        /// Automatically assign gun type
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            gunType = GunTypes.Handcannon;
        }
    }
}
