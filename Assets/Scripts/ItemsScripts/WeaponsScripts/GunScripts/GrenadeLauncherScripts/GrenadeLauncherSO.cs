using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.GrenadeLauncherScripts
{
    [CreateAssetMenu(fileName = "GrenadeLauncherSO", menuName = "Scriptable Objects/GrenadeLauncherSO")]
    public class GrenadeLauncherSO : GunSO
    {
        [Header("Grenade Launcher Attributes")]
        public int grenadeLauncherType;

        protected override void OnEnable()
        {
            base.OnEnable();
            gunType = (int) Guns.GunTypes.GrenadeLauncher;
        }
    }
    
}
