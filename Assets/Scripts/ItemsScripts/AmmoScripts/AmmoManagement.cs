using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Player;
using Unity.VisualScripting;
using UnityEngine;


namespace ItemScripts.AmmoManagement
{
    public class AmmoManagement : MonoBehaviour
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

        [Header("Overall Ammo Tracker")]
        public List<Ammo> ammoTracker;

        [Header("Trackers For Individual Ammo Types")]
        /// For each specific ammo tracker, it keeps track of 
        /// the ammoTracker slot it takes up
        public List<int> pistolAmmoTracker;
        public List<int> shotgunAmmoTracker;
        public List<int> smgAmmoTracker;
        public bool collectSMGAmmo;
        public List<int> sniperAmmoTracker;
        public bool collectSniperAmmo;
        public List<int> handcannonAmmoTracker;
        public bool collectHandcannonAmmo;
        public List<int> grenadeLauncherAmmoTracker;
        public bool collectGrenadeLauncherAmmo;

        [Header("Trackers Of Ammo Types")]
        public int[] ammoTypeTracker;
        

        public void AddAmmo(int ammoInsertType, int ammoInsertAmount)
        {
            for(int i = 0; i < ammoTypeTracker.Count(); i++)
            {
                //Check that player has ammo type tracked
                if(ammoTypeTracker[i] == ammoInsertType)
                {
                    List<int> tempAmmoTracker = GetAmmoTypeList(ammoInsertType);
                    for(int x = 0; x < tempAmmoTracker.Count(); x++)
                    {
                        int tempAmmo = tempAmmoTracker[x];
                        int tempAmmoMax = ammoTracker[tempAmmo].maxAmmo;
                        int tempCurrentAmmo = ammoTracker[tempAmmo].currentAmmo;    
                        if(ammoInsertAmount < tempAmmoMax)
                        {
                            if(ammoInsertAmount + tempCurrentAmmo > tempAmmoMax)
                            {
                                int ammoLeft = tempCurrentAmmo + ammoInsertAmount - tempAmmoMax;
                                ammoTracker[tempAmmo].currentAmmo = tempAmmoMax;
                                AddAmmo(ammoInsertType, ammoLeft);
                            }
                            else
                            {
                                ammoTracker[tempAmmo].currentAmmo += ammoInsertAmount;
                                return;  
                            }
   
                        }
                    }
                }
            }

            ///if the inventory isn't full, then create a new ammo brick
            /// for the specific ammo type and add it to that ammo tracking type
            //if(inventory != full)
            //ammoTracker.Append(ammoInsert);
            //else return that you cannot add to inventory 
        }

        public List<int> GetAmmoTypeList(int ammoType)
        {
            List<int> ammoTrackingList = new List<int>();
            switch (ammoType)
            {
                case (int) AmmoTypes.PistolAmmo:
                    for(int pa = 0; pa < pistolAmmoTracker.Count();pa++)
                        ammoTrackingList.Append(pistolAmmoTracker[pa]);                   
                    break;
                case (int) AmmoTypes.ShotgunAmmo:
                    for(int sha = 0; sha < shotgunAmmoTracker.Count(); sha++)
                        ammoTrackingList.Append(shotgunAmmoTracker[sha]);
                    break;
                
            }
            return ammoTrackingList;
        }



        public class Ammo : Items
        {
            [Header("Ammo Identification")]
            public string ammoName;
            public int ammoType;
            public int inverntoryLocation;

            [Header("Ammo Attributes")]
            public int currentAmmo;
            public int maxAmmo;
            public float dropChance;
        }

        public class PistolAmmo : Ammo
        {
            public PistolAmmo(int inventorySlot, int ammoAmount)
            {
                ammoName = "Pistol Ammo";
                ammoType = (int) AmmoTypes.PistolAmmo;
                inverntoryLocation = inventorySlot;

                currentAmmo = ammoAmount;
                maxAmmo = 45;
                dropChance = 0.40f;
            }



        }

        public class ShotgunAmmo : Ammo
        {
            public ShotgunAmmo(int inventroySlot, int ammoAmount)
            {
                ammoName = "Shotgun Ammo";
                ammoType = (int) AmmoTypes.ShotgunAmmo;
                inverntoryLocation = inventroySlot;

                currentAmmo = ammoAmount;
                maxAmmo = 30;
                dropChance = 0.33f;
            }

        }

        public class SMGAmmo : Ammo
        {
            public SMGAmmo(int inventroySlot, int ammoAmount)
            {
                ammoName = "SMG Ammo";
                ammoType = (int) AmmoTypes.SMGAmmo;
                inverntoryLocation = inventroySlot;

                currentAmmo = ammoAmount;
                maxAmmo = 60;
                dropChance = 0.33f;
            }
        }

        public class RifleAmmo : Ammo
        {
            public RifleAmmo(int inventroySlot, int ammoAmount)
            {
                ammoName = "Rifle Ammo";
                ammoType = (int) AmmoTypes.RifleAmmo;                
                inverntoryLocation = inventroySlot;

                currentAmmo = ammoAmount;
                maxAmmo = 40;
                dropChance = 0.33f;
            }

            
        }

        public class SniperAmmo : Ammo
        {
            public SniperAmmo(int inventroySlot, int ammoAmount)
            {
                
                ammoName = "Sniper Ammo";
                ammoType = (int) AmmoTypes.SniperAmmo;                
                inverntoryLocation = inventroySlot;

                currentAmmo = ammoAmount;
                maxAmmo = 15;
                dropChance = 0.15f;
            }
        }

        public class HandcannonAmmo : Ammo
        {
            public HandcannonAmmo(int inventroySlot, int ammoAmount)
            {
                ammoName = "HandcannonAmmo";
                ammoType = (int) AmmoTypes.HandcannonAmmo;                
                inverntoryLocation = inventroySlot;

                currentAmmo = ammoAmount;                
                maxAmmo = 15;
                dropChance = 0.1f;
            }
        }

        public class GrenadeLauncherAmmo : Ammo
        {
            public GrenadeLauncherAmmo(int inventroySlot, int ammoAmount)
            {
                ammoName = "Grenade Launcer Ammo";
                ammoType = (int) AmmoTypes.GrenadeLauncherAmmo;                
                inverntoryLocation = inventroySlot;

                currentAmmo = ammoAmount;
                maxAmmo = 5;
                dropChance = 0.1f;
            }

        }
        
    }
}
