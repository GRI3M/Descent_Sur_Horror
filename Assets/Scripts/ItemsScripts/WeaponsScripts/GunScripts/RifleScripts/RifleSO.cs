using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.RifleScripts
{
    [CreateAssetMenu(fileName = "RifleSO", menuName = "Scriptable Objects/RifleSO")]
    public class RifleSO : GunSO
    {
        [Header("Rifle Attributes")]
        public int rifleType;

        protected override void OnEnable()
        {
            base.OnEnable();
            gunType = (int) Guns.GunTypes.Rifle;
        }
    }
}
