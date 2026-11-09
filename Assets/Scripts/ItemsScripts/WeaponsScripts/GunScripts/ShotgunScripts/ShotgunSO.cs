using UnityEngine;
namespace ItemScripts.WeaponScripts.GunScripts.ShotgunScripts
{
    [CreateAssetMenu(fileName = "ShotgunSO", menuName = "Scriptable Objects/ShotgunSO")]
    public class ShotgunSO : GunSO
    {
        [Header("Shotgun Attributes")]
        public ShotgunTypes shotgunType;

        /// <summary>
        /// Automatically assign gun type
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            gunType = GunTypes.Shotgun;
            isDualSlot = true;
        }
    }
}
