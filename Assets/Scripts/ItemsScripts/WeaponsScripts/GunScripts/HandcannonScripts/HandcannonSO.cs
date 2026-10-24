using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.HandcannonScript
{
    [CreateAssetMenu(fileName = "HandcannonSO", menuName = "Scriptable Objects/HandcannonSO")]
    public class HandcannonSO : GunSO
    {
        public int handcannonType;

        protected override void OnEnable()
        {
            base.OnEnable();
            gunType = (int) Guns.GunTypes.Handcannon;
        }
    }
}
