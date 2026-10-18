using UnityEngine;


namespace ItemScripts.AmmoManagement
{
    public class AmmoManagement : Items
    {

        public enum AmmoTypes
        {
            PistolAmmo,
            ShotgunAmmo,
            SMGAmmo,
            RifleAmmo,
            SniperAmmo,
            HandcannonAmmo,
            GrenadeLauncherAmmo,
        }

        public class Ammo : AmmoManagement
        {
            [Header("Ammo Identification")]
            public string ammoName;
            public int ammoType;

            [Header("Ammo Attributes")]
            public int currentAmmo;
            public int maxAmmo;
            public float dropChance;
        }

        public class PistolAmmo : Ammo
        {
            public PistolAmmo()
            {
                ammoName = "Pistol Ammo";
                ammoType = (int) AmmoTypes.PistolAmmo;

                maxAmmo = 45;
                dropChance = 0.30f;
            }

        }

        public class ShotgunAmmo : Ammo
        {
            public ShotgunAmmo()
            {
                ammoName = "Shotgun Ammo";
                ammoType = (int) AmmoTypes.ShotgunAmmo;

                maxAmmo = 30;
            }

        }

        public class SMGAmmo : Ammo
        {
            public SMGAmmo()
            {
                ammoName = "SMG Ammo";
                ammoType = (int) AmmoTypes.SMGAmmo;

                maxAmmo = 60;
            }
        }

        public class RifleAmmo : Ammo
        {
            public RifleAmmo()
            {
                ammoName = "Rifle Ammo";
                ammoType = (int) AmmoTypes.RifleAmmo;

                maxAmmo = 40;
            }

            
        }

        public class SniperAmmo : Ammo
        {
            public SniperAmmo()
            {
                
                ammoName = "Sniper Ammo";
                ammoType = (int) AmmoTypes.SniperAmmo;

                maxAmmo = 15;
                dropChance = 0.15f;
            }
        }

        public class HandcannonAmmo : Ammo
        {
            public HandcannonAmmo()
            {
                ammoName = "HandcannonAmmo";
                ammoType = (int) AmmoTypes.HandcannonAmmo;
                
                maxAmmo = 15;
            }
        }

        public class GrenadeLauncherAmmo : Ammo
        {
            public GrenadeLauncherAmmo()
            {
                ammoName = "Grenade Launcer Ammo";
                ammoType = (int) AmmoTypes.GrenadeLauncherAmmo;

                maxAmmo = 5;
            }

        }
        
    }
}
