using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.SMGScripts
{
    [CreateAssetMenu(fileName = "SMGSO", menuName = "Scriptable Objects/SMGSO")]
    public class SMGSO : GunSO
    {
        [Header("SMG Attributes")]
        public SMGTypes smgTypes;

        /// <summary>
        /// Automatically assign gun type
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            gunType = GunTypes.SMG;
        }
    }
    
}
