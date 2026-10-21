using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ItemScripts.WeaponScripts.GunScripts.PistolScripts;
using Player;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.Rendering;


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
        [Header("Player Inventory Tie-in")]
        public PlayerInventory playerInventory;

        [Header("Overall Ammo Tracker")]
        public List<Ammo> ammoTracker;

        [Header("Trackers For Individual Ammo Types")]
        /// For each specific ammo tracker, it keeps track of 
        /// the ammoTracker slot it takes up
        /// Might remove the bools and create a method that checks 
        /// that a weapons ammo tracker has a count that's greater than 0
        public List<AmmoInventoryTracker> pistolAmmoTracker;
        public bool collectPistolAmmo;
        public List<AmmoInventoryTracker> shotgunAmmoTracker;
        public bool collectShotgunAmmo;
        public List<AmmoInventoryTracker> smgAmmoTracker;
        public bool collectSMGAmmo;
        public List<AmmoInventoryTracker> sniperAmmoTracker;
        public bool collectSniperAmmo;
        public List<AmmoInventoryTracker> rifleAmmoTracker;
        public bool collectRifleAmmo;
        public List<AmmoInventoryTracker> handcannonAmmoTracker;
        public bool collectHandcannonAmmo;
        public List<AmmoInventoryTracker> grenadeLauncherAmmoTracker;
        public bool collectGrenadeLauncherAmmo;

        [Header("Trackers Of Ammo Types")]
        public int[] ammoTypeTracker = new int[7];
        

        public void AddAmmo(int ammoInsertType, int ammoInsertAmount)
        {

            /// Remove this check and update it to check the ammo type list count
            /// for the specific ammo type. this could be a method, if the Ammo Inventory Tracker is deleted
            /// from the list, then it can be deleted
            for(int i = 0; i < ammoTypeTracker.Count(); i++)
            {
                //Check that player has ammo type tracked
                if(ammoTypeTracker[i] == ammoInsertType)
                {
                    List<AmmoInventoryTracker> tempAmmoTracker = GetAmmoTypeList(ammoInsertType);
                    for(int x = 0; x < tempAmmoTracker.Count(); x++)
                    {
                        Ammo tempAmmo = ammoTracker[tempAmmoTracker[x].ammoTrackerSlot];
                        int tempAmmoMax = tempAmmo.maxAmmo;
                        int tempCurrentAmmo = tempAmmo.currentAmmo;    
                        if(ammoInsertAmount < tempAmmoMax)
                        {
                            if(ammoInsertAmount + tempCurrentAmmo > tempAmmoMax)
                            {
                                int ammoLeft = tempCurrentAmmo + ammoInsertAmount - tempAmmoMax;
                                ammoTracker[tempAmmoTracker[x].ammoTrackerSlot].currentAmmo = tempAmmoMax;
                                AddAmmo(ammoInsertType, ammoLeft);
                            }
                            else
                            {
                                ammoTracker[tempAmmoTracker[x].ammoTrackerSlot].currentAmmo += ammoInsertAmount;
                                return;  
                            }
   
                        }
                    }
                }
            }
            int tempInventoryRow = -1;
            int tempInventoryColumn = -1;
            if (!playerInventory.CheckInventoryFull(out tempInventoryRow, out tempInventoryColumn))
            {
                //Need to test this because it should get the next spot that's going to be avaliable after appending
                Ammo tempAmmo = CreateAmmo(ammoInsertType, new AmmoInventoryTracker(tempInventoryRow, tempInventoryColumn, ammoTracker.Count(), ammoInsertType), ammoInsertAmount);
                ammoTracker.Append(tempAmmo);
            }
            else
            {
                
            }
            ///if the inventory isn't full, then create a new ammo brick
            /// for the specific ammo type and add it to that ammo tracking type
            //if(inventory != full)
            //ammoTracker.Append(ammoInsert);
            //else return that you cannot add to inventory 
        }

        public List<AmmoInventoryTracker> GetAmmoTypeList(int ammoType)
        {
            switch (ammoType)
            {
                case (int) AmmoTypes.PistolAmmo:
                    return pistolAmmoTracker;
                case (int) AmmoTypes.ShotgunAmmo:
                    return shotgunAmmoTracker;
                case (int) AmmoTypes.SniperAmmo:
                    return sniperAmmoTracker;
                case (int) AmmoTypes.SMGAmmo:
                    return smgAmmoTracker;
                case (int) AmmoTypes.RifleAmmo:
                    return rifleAmmoTracker;
                case (int) AmmoTypes.HandcannonAmmo:
                    return handcannonAmmoTracker;
                case(int) AmmoTypes.GrenadeLauncherAmmo:
                    return grenadeLauncherAmmoTracker; 
            }
            List<AmmoInventoryTracker> ammoTrackingList = new List<AmmoInventoryTracker>();
            return ammoTrackingList;
        }

        public Ammo CreateAmmo(int ammoType, AmmoInventoryTracker ait, int ammoAmount)
        {
            switch (ammoType)
            {
                case (int) AmmoTypes.PistolAmmo:
                    pistolAmmoTracker.Add(ait);
                    return new PistolAmmo(ait, ammoAmount);
                case (int) AmmoTypes.ShotgunAmmo:
                    shotgunAmmoTracker.Add(ait);
                    return new ShotgunAmmo(ait, ammoAmount);
                case (int) AmmoTypes.SniperAmmo:
                    sniperAmmoTracker.Add(ait);
                    return new SniperAmmo(ait, ammoAmount);
                case (int) AmmoTypes.SMGAmmo:
                    smgAmmoTracker.Add(ait);
                    return new SMGAmmo(ait, ammoAmount);
                case (int) AmmoTypes.RifleAmmo:
                    rifleAmmoTracker.Add(ait);
                    return new RifleAmmo(ait, ammoAmount);
                case (int) AmmoTypes.HandcannonAmmo:
                    handcannonAmmoTracker.Add(ait);
                    return new HandcannonAmmo(ait, ammoAmount);
                case(int) AmmoTypes.GrenadeLauncherAmmo:
                    grenadeLauncherAmmoTracker.Add(ait);
                    return new GrenadeLauncherAmmo(ait, ammoAmount);
            }
            return new PistolAmmo(ait, ammoAmount);
        }







        public class Ammo : Items
        {
            [Header("Ammo Identification")]
            public string ammoName;
            public int ammoType;
            public AmmoInventoryTracker inventoryTracker;

            [Header("Ammo Attributes")]
            public int currentAmmo;
            public int maxAmmo;
            public float dropChance;
        }

        public class PistolAmmo : Ammo
        {
            public PistolAmmo(AmmoInventoryTracker inventorySlot, int ammoAmount)
            {
                ammoName = "Pistol Ammo";
                ammoType = (int) AmmoTypes.PistolAmmo;
                inventoryTracker = inventorySlot;

                currentAmmo = ammoAmount;
                maxAmmo = 45;
                dropChance = 0.40f;
            }


        }

        public class ShotgunAmmo : Ammo
        {
            public ShotgunAmmo(AmmoInventoryTracker inventroySlot, int ammoAmount)
            {
                ammoName = "Shotgun Ammo";
                ammoType = (int) AmmoTypes.ShotgunAmmo;
                inventoryTracker = inventroySlot;

                currentAmmo = ammoAmount;
                maxAmmo = 30;
                dropChance = 0.33f;
            }

        }

        public class SMGAmmo : Ammo
        {
            public SMGAmmo(AmmoInventoryTracker inventroySlot, int ammoAmount)
            {
                ammoName = "SMG Ammo";
                ammoType = (int) AmmoTypes.SMGAmmo;
                inventoryTracker = inventroySlot;

                currentAmmo = ammoAmount;
                maxAmmo = 60;
                dropChance = 0.33f;
            }
        }

        public class RifleAmmo : Ammo
        {
            public RifleAmmo(AmmoInventoryTracker inventroySlot, int ammoAmount)
            {
                ammoName = "Rifle Ammo";
                ammoType = (int) AmmoTypes.RifleAmmo;                
                inventoryTracker = inventroySlot;

                currentAmmo = ammoAmount;
                maxAmmo = 40;
                dropChance = 0.33f;
            }

            
        }

        public class SniperAmmo : Ammo
        {
            public SniperAmmo(AmmoInventoryTracker inventroySlot, int ammoAmount)
            {
                
                ammoName = "Sniper Ammo";
                ammoType = (int) AmmoTypes.SniperAmmo;                
                inventoryTracker = inventroySlot;

                currentAmmo = ammoAmount;
                maxAmmo = 15;
                dropChance = 0.15f;
            }
        }

        public class HandcannonAmmo : Ammo
        {
            public HandcannonAmmo(AmmoInventoryTracker inventroySlot, int ammoAmount)
            {
                ammoName = "HandcannonAmmo";
                ammoType = (int) AmmoTypes.HandcannonAmmo;                
                inventoryTracker = inventroySlot;

                currentAmmo = ammoAmount;                
                maxAmmo = 15;
                dropChance = 0.1f;
            }
        }

        public class GrenadeLauncherAmmo : Ammo
        {
            public GrenadeLauncherAmmo(AmmoInventoryTracker inventroySlot, int ammoAmount)
            {
                ammoName = "Grenade Launcer Ammo";
                ammoType = (int) AmmoTypes.GrenadeLauncherAmmo;                
                inventoryTracker = inventroySlot;

                currentAmmo = ammoAmount;
                maxAmmo = 5;
                dropChance = 0.1f;
            }

        }

        public class ErrorAmmo : Ammo
        {
            public ErrorAmmo()
            {
                ammoName = "This is a Error";
                ammoType = -1;
            }
        }

        public class AmmoInventoryTracker : MonoBehaviour
        {
            public int inventoryRow;
            public int inventoryColumn;
            public int ammoTrackerSlot;
            public int ammoType;

            public AmmoInventoryTracker(int ir, int ic, int ats, int at)
            {
                inventoryRow = ir;
                inventoryRow = ic;
                ammoTrackerSlot = ats;
                ammoType = at;
            }
        }
        
    }
}
