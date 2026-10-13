using UnityEngine;


namespace ItemScripts.WeaponScripts.GunScripts
{
    public class Guns : Weapons
    {
        
        [SerializeField] public int capacity;
        [SerializeField] public float reloadSpeed;
        [SerializeField] public float fireRate;
        [SerializeField] public bool automatic = false;
        [SerializeField] public int WeaponType;


        public enum GunTypes
        {
            Pistol,
            Shotgun,
            Rifle,
            Sniper,
            SMG,
            Magnum,
            GrenadeLauncher,
        }




    }
}
