using UnityEngine;
namespace ItemScripts.WeaponScripts.GunScripts.ShotgunScripts
{
    [CreateAssetMenu(fileName = "ShotgunSO", menuName = "Scriptable Objects/ShotgunSO")]
    public class ShotgunSO : GunSO
    {
        [Header("Shotgun Attributes")]
        public int shotgunType;

        protected override void OnEnable()
        {
            base.OnEnable();
            gunType = (int) Guns.GunTypes.Shotgun;
        }
    }
}
