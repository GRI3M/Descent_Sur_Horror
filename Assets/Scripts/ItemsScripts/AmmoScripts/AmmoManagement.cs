using UnityEngine;


namespace ItemScripts
{
    public class AmmoManagement : Items
    {

        public enum ammoTypes
        {
            PistolAmmo,
            ShotgunAmmo,
            SubmachineGunAmmo,
            RifleAmmo,
            SniperAmmo,
            MagnumAmmo,
        }

        public class PistolAmmo : Items
        {
            public int currentAmmo;
            public int maxAmmo = 45;

        }

        public class ShotgunAmmo : Items
        {
            public int currentAmmo;
            public int maxAmmo = 30;
        }

        public class SubmachineGunAmmo : Items
        {
            public int currentAmmo;
            public int maxAmmo = 60;
        }

        public class RifleAmmo : Items
        {
            public int currentAmmo;
            public int maxAmmo = 40;
        }

        public class SniperAmmo : Items
        {
            public int currentAmmo;
            public int maxAmmo = 15;
        }

        public class MagnumAmmo : Items
        {
            public int currentAmmo;
            public int maxAmmo = 15;
        }

        public class GrenadeLauncherAmmo : Items
        {
            public int currentAmmo;
            public int maxAmmo = 5;
        }
        
    }
}
