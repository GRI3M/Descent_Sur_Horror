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
using ItemScripts.AmmoScript;


namespace ItemScripts.AmmoManagementScript
{
    public class AmmoManagement : MonoBehaviour
    {
        

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

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ammoInsertType">The type of ammo being inserted</param>
        /// <param name="ammoInsertAmount">The amount of ammo being inserted</param>
        /// <returns> whether the ammo was added or not</returns>
        public bool AddAmmo(int ammoInsertType, int ammoInsertAmount)
        {
            if(CheckAmmoType(ammoInsertType))
            {
                List<Ammo> tempAmmoTracker = GetAmmoTypeList(ammoInsertType);
                for(int x = 0; x < tempAmmoTracker.Count(); x++)
                {
                    ///Condense this down to a method
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
                    ///Condense all above down to a single method
                }
            }
            ///Condense down to method
            int tempInventoryRow = -1;
            int tempInventoryColumn = -1;
            if (!playerInventory.CheckInventoryFull(out tempInventoryRow, out tempInventoryColumn))
            {
                CreateAmmo(ammoInsertType, new AmmoInventoryTracker(tempInventoryRow, tempInventoryColumn), ammoInsertAmount);
                return true;
            }
            else
            {
                return false;   
            }
            ///Condense above down to a method

            ///if the inventory isn't full, then create a new ammo brick
            /// for the specific ammo type and add it to that ammo tracking type
            //if(inventory != full)
            //ammoTracker.Append(ammoInsert);
            //else return that you cannot add to inventory 
        }

        /// <summary>
        /// Gets the ammo list of the ammo type inserted
        /// </summary>
        /// <param name="ammoType">The type of ammo needed</param>
        /// <returns>The ammo type tracking list</returns>
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

        /// <summary>
        /// Checks if there are any ammo bricks for the ammo attempting to be added
        /// </summary>
        /// <param name="ammoType">The type of ammo needed</param>
        /// <returns> If there is ammo avalible to add to </returns>
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

        /// <summary>
        /// Updates the inventory and ammo tracker to the new ammount (can be more or less)
        /// </summary>
        /// <param name="ammoType">The ammo type needed</param>
        /// <param name="ammoAmount">The amount of ammo</param>
        /// <param name="ammoSlot">The ammo slot the ammo occupies</param>
        /// <param name="ait">The inventory slot the ammo occupies</param>
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

        /// <summary>
        /// Creates a new ammo brick and adds it to the inventory and ammo tracker
        /// </summary>
        /// <param name="ammoType">The ammo type needed</param>
        /// <param name="ait">The inventory slot the ammo will take up</param>
        /// <param name="ammoAmount">The amount of ammo being created</param>
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




        
        
    }
}
