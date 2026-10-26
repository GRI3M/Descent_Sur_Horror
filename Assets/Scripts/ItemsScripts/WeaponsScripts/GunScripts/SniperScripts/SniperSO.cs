using UnityEngine;
namespace ItemScripts.WeaponScripts.GunScripts.SniperScripts
{
    [CreateAssetMenu(fileName = "SniperSO", menuName = "Scriptable Objects/SniperSO")]
    public class SniperSO : GunSO
    {
        [Header("Sniper Attributes")]
        public int sniperType;
        public bool rechamber;

        protected override void OnEnable()
        {
            base.OnEnable();
            gunType = (int) Guns.GunTypes.Sniper;
            CanZoom = true;
        }
    }
}
