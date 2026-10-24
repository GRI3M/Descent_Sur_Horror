using UnityEngine;

namespace ItemScripts.WeaponScripts.GunScripts.SMGScripts
{
    [CreateAssetMenu(fileName = "SMGSO", menuName = "Scriptable Objects/SMGSO")]
    public class SMGSO : GunSO
    {
        [Header("SMG Attributes")]
        public int smgTypes;
        protected override void OnEnable()
        {
            base.OnEnable();
            gunType = (int) Guns.GunTypes.SMG;
        }
    }
    
}
