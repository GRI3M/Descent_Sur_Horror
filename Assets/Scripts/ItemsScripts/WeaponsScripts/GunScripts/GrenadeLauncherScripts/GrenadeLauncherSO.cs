using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.GrenadeLauncherScripts
{
    [CreateAssetMenu(fileName = "GrenadeLauncherSO", menuName = "Scriptable Objects/GrenadeLauncherSO")]
    public class GrenadeLauncherSO : GunSO
    {
        public int grenadeLauncherType;

        protected override void OnEnable()
        {
            base.OnEnable();
            gunType = (int) Guns.GunTypes.GrenadeLauncher;
        }
    }
    
}
