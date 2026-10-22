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

        [Header("Trackers For Individual Ammo Types")]
        public List<Ammo> pistolAmmoTracker;
        public List<Ammo> shotgunAmmoTracker;
        public List<Ammo> smgAmmoTracker;
        public List<Ammo> sniperAmmoTracker;
        public List<Ammo> rifleAmmoTracker;
        public List<Ammo> handcannonAmmoTracker;
        public List<Ammo> grenadeLauncherAmmoTracker;

        

        public bool AddAmmo(int ammoInsertType, int ammoInsertAmount)
        {
            if(CheckAmmoType(ammoInsertType))
            {
                List<Ammo> tempAmmoTracker = GetAmmoTypeList(ammoInsertType);
                for(int x = 0; x < tempAmmoTracker.Count(); x++)
                {
                    Ammo tempAmmo = tempAmmoTracker[x];
                    int tempAmmoMax = tempAmmo.maxAmmo;
                    int tempCurrentAmmo = tempAmmo.currentAmmo;    
                    if(ammoInsertAmount < tempAmmoMax)
                    {
                        if(ammoInsertAmount + tempCurrentAmmo > tempAmmoMax)
                        {
                            int ammoLeft = tempCurrentAmmo + ammoInsertAmount - tempAmmoMax;
                            UpdateAmmo(ammoInsertType, tempAmmoMax, x, tempAmmo.inventoryTracker);
                            AddAmmo(ammoInsertType, ammoLeft);
                        }
                        else
                        {
                            UpdateAmmo(ammoInsertType, tempCurrentAmmo + ammoInsertAmount, x, tempAmmo.inventoryTracker);
                            return true;  
                        }

                    }
                }
            }
            int tempInventoryRow = -1;
            int tempInventoryColumn = -1;
            if (!playerInventory.CheckInventoryFull(out tempInventoryRow, out tempInventoryColumn))
            {
                CreateAmmo(ammoInsertType, new AmmoInventoryTracker(tempInventoryRow, tempInventoryColumn, ammoInsertType), ammoInsertAmount);
                return true;
            }
            else
            {
                return false;   
            }
            ///if the inventory isn't full, then create a new ammo brick
            /// for the specific ammo type and add it to that ammo tracking type
            //if(inventory != full)
            //ammoTracker.Append(ammoInsert);
            //else return that you cannot add to inventory 
        }

        public List<Ammo> GetAmmoTypeList(int ammoType)
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
            List<Ammo> ammoTrackingList = new List<Ammo>();
            return ammoTrackingList;
        }

        public bool CheckAmmoType(int ammoType)
        {
            switch (ammoType)
            {
                case (int) AmmoTypes.PistolAmmo:
                    return pistolAmmoTracker.Count() > 0;
                case (int) AmmoTypes.ShotgunAmmo:
                    return shotgunAmmoTracker.Count() > 0;
                case (int) AmmoTypes.SniperAmmo:
                    return sniperAmmoTracker.Count() > 0;
                case (int) AmmoTypes.SMGAmmo:
                    return smgAmmoTracker.Count() > 0;
                case (int) AmmoTypes.RifleAmmo:
                    return rifleAmmoTracker.Count() > 0;
                case (int) AmmoTypes.HandcannonAmmo:
                    return handcannonAmmoTracker.Count() > 0;
                case(int) AmmoTypes.GrenadeLauncherAmmo:
                    return grenadeLauncherAmmoTracker.Count() > 0;
            }
            return false;
        }

        public void UpdateAmmo(int ammoType, int ammoAmount, int ammoSlot, AmmoInventoryTracker ait)
        {
            switch (ammoType)
            {
                case (int) AmmoTypes.PistolAmmo:
                    pistolAmmoTracker[ammoSlot].currentAmmo = ammoAmount;
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = pistolAmmoTracker[ammoSlot];
                    return;
                case (int) AmmoTypes.ShotgunAmmo:
                    shotgunAmmoTracker[ammoSlot].currentAmmo = ammoAmount;
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = shotgunAmmoTracker[ammoSlot];
                    return;
                case (int) AmmoTypes.SniperAmmo:
                    sniperAmmoTracker[ammoSlot].currentAmmo = ammoAmount;
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = sniperAmmoTracker[ammoSlot];
                    return;
                case (int) AmmoTypes.SMGAmmo:
                    smgAmmoTracker[ammoAmount].currentAmmo = ammoAmount;
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = smgAmmoTracker[ammoAmount];
                    return;
                case (int) AmmoTypes.RifleAmmo:
                    rifleAmmoTracker[ammoAmount].currentAmmo = ammoAmount;
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = rifleAmmoTracker[ammoSlot];
                    return;
                case (int) AmmoTypes.HandcannonAmmo:
                    handcannonAmmoTracker[ammoSlot].currentAmmo = ammoAmount;
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = handcannonAmmoTracker[ammoSlot];
                    return;
                case(int) AmmoTypes.GrenadeLauncherAmmo:
                    grenadeLauncherAmmoTracker[ammoSlot].currentAmmo = ammoAmount;
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = handcannonAmmoTracker[ammoSlot];
                    return;
            }
        }

        public void CreateAmmo(int ammoType, AmmoInventoryTracker ait, int ammoAmount)
        {
            switch (ammoType)
            {
                case (int) AmmoTypes.PistolAmmo:
                    PistolAmmo tempPAmmo = new PistolAmmo(ait, ammoAmount);
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryRow] = tempPAmmo;
                    pistolAmmoTracker.Add(tempPAmmo);
                    return;
                case (int) AmmoTypes.ShotgunAmmo:
                    ShotgunAmmo tempShAmmo = new ShotgunAmmo(ait, ammoAmount);
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryRow] = tempShAmmo;
                    shotgunAmmoTracker.Add(tempShAmmo);
                    return;
                case (int) AmmoTypes.SniperAmmo:
                    SniperAmmo tempSnAmmo = new SniperAmmo(ait, ammoAmount);
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryRow] = tempSnAmmo;
                    sniperAmmoTracker.Add(tempSnAmmo);
                    return;
                case (int) AmmoTypes.SMGAmmo:
                    SMGAmmo tempSMGAmmo = new SMGAmmo(ait, ammoAmount);
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryRow] = tempSMGAmmo;
                    smgAmmoTracker.Add(tempSMGAmmo);
                    return;
                case (int) AmmoTypes.RifleAmmo:
                    RifleAmmo tempRAmmo = new RifleAmmo(ait, ammoAmount);
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryRow] = tempRAmmo;
                    rifleAmmoTracker.Add(tempRAmmo);
                    return;
                case (int) AmmoTypes.HandcannonAmmo:
                    HandcannonAmmo tempHAmmo = new HandcannonAmmo(ait, ammoAmount);
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryRow] = tempHAmmo;
                    handcannonAmmoTracker.Add(tempHAmmo);
                    return;
                case(int) AmmoTypes.GrenadeLauncherAmmo:
                    GrenadeLauncherAmmo tempGLAmmo = new GrenadeLauncherAmmo(ait, ammoAmount);
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryRow] = tempGLAmmo;
                    grenadeLauncherAmmoTracker.Add(tempGLAmmo);
                    return;
            }
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
            public int ammoType;

            public AmmoInventoryTracker(int ir, int ic, int at)
            {
                inventoryRow = ir;
                inventoryRow = ic;
                ammoType = at;
            }
        }
        
    }
}
