using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.GrenadeLauncherScripts
{
    [CreateAssetMenu(fileName = "GrenadeLauncherSO", menuName = "Scriptable Objects/GrenadeLauncherSO")]
    public class GrenadeLauncherSO : GunSO
    {
        [Header("Grenade Launcher Attributes")]
        public GrenadeLauncherTypes grenadeLauncherTypes;
        
        /// <summary>
        /// Automatically assign gun type
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            gunType = GunTypes.GrenadeLauncher;
            isDualSlot = true;
        }
    }
    
}
