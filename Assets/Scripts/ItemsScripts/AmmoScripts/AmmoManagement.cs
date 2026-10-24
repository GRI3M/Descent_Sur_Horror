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
        /// Adds ammo to either a current ammo brick or creates a new ammo brick to add it to
        /// </summary>
        /// <param name="ammoInsertType">The type of ammo being inserted</param>
        /// <param name="ammoInsertAmount">The amount of ammo being inserted</param>
        /// <returns> whether the ammo was added or not</returns>
        // public bool AddAmmo(int ammoInsertType, int ammoInsertAmount)
        // {
        //     if (CheckAmmoType(ammoInsertType))
        //     {
        //         List<Ammo> tempAmmoTracker = GetAmmoTypeList(ammoInsertType);
        //         int ammoLeft = ammoInsertAmount;
        //         for (int x = 0; x < tempAmmoTracker.Count(); x++)
        //         {  ///If The current Ammo count is less than the max, then add to ammo
        //             if (tempAmmoTracker[x].currentAmmo < tempAmmoTracker[x].maxAmmo)
        //                 ///Add to ammo, if the added ammo is depleted, then return true, else add to next brick
        //                 if (HandleAddToAmmo(tempAmmoTracker[x], ref ammoLeft, x)) return true;
        //         } ///If ammo is not added to an existing pile  
        //     }
        //     return HandleAddNewAmmo(ammoInsertType, ammoInsertAmount);
        // }

        /// <summary>
        /// If there is room in the inventory, create a new ammo brick
        /// </summary>
        /// <param name="ammoInsertType">Ammo type being added</param>
        /// <param name="ammoInsertAmount">The amount of ammo being created</param>
        /// <returns>If an ammo brick is created or not</returns>
        // private bool HandleAddNewAmmo(int ammoInsertType, int ammoInsertAmount)
        // {
        //     if (!playerInventory.CheckInventoryFull(out int tempInventoryRow, out int tempInventoryColumn))
        //     {
        //         CreateAmmo(ammoInsertType, new AmmoInventoryTracker(tempInventoryRow, tempInventoryColumn), ammoInsertAmount);
        //         return true;
        //     }
        //     else return false;
        // }


        /// <summary>
        /// Handles the reload and updates ammo or removes the ammo brick from storage
        /// </summary>
        /// <param name="ammo">The ammo brick being updated/deleted</param>
        /// <param name="listPos">The position in the ammo list</param>
        public void HandleReload(Ammo ammo, int listPos)
        {
            if (ammo.currentAmmo == 0) DeleteAmmo(ammo.ammoType, listPos, ammo.inventoryTracker);
            else UpdateAmmo(ammo.ammoType, ammo.currentAmmo, listPos, ammo.inventoryTracker);
        }

        /// <summary>
        /// Depletes ammo from the ammo brick before deleting it
        /// </summary>
        /// <param name="ammo">The ammo brick</param>
        /// <param name="listPos">Where the ammo brick is</param>
        /// <param name="reloadAmount">How much will be extracted from the ammo brick before deletion</param>
        public void HandleDepleteAmmo(Ammo ammo, int listPos, ref int reloadAmount)
        {
            reloadAmount += ammo.currentAmmo;
            DeleteAmmo(ammo.ammoType, listPos, ammo.inventoryTracker);
        }

        /// <summary>
        /// Handles adding to Ammo
        /// </summary>
        /// <param name="tempAmmo">The ammo brick attempting to be added to</param>
        /// <param name="ammoAmount">The amount of ammo that will be added</param>
        /// <param name="listPos">The position in the list the ammo brick is located</param>
        /// <returns>Returns i</returns>
        private bool HandleAddToAmmo(Ammo tempAmmo, ref int ammoAmount, int listPos)
        {            
            if((ammoAmount + tempAmmo.currentAmmo) > tempAmmo.maxAmmo)
            {
                ammoAmount = tempAmmo.currentAmmo + ammoAmount - tempAmmo.maxAmmo;
                UpdateAmmo(tempAmmo.ammoType, tempAmmo.maxAmmo, listPos, tempAmmo.inventoryTracker);
                return false;
            }
            else
            {
                UpdateAmmo(tempAmmo.ammoType, tempAmmo.currentAmmo + ammoAmount, listPos, tempAmmo.inventoryTracker);
                return true;  
            }
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
        private void UpdateAmmo(int ammoType, int ammoAmount, int ammoSlot, AmmoInventoryTracker ait)
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
                    smgAmmoTracker[ammoSlot].currentAmmo = ammoAmount;
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = smgAmmoTracker[ammoAmount];
                    return;
                case (int) AmmoTypes.RifleAmmo:
                    rifleAmmoTracker[ammoSlot].currentAmmo = ammoAmount;
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
        private void CreateAmmo(int ammoType, AmmoInventoryTracker ait, int ammoAmount)
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
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = tempShAmmo;
                    shotgunAmmoTracker.Add(tempShAmmo);
                    return;
                case (int) AmmoTypes.SniperAmmo:
                    SniperAmmo tempSnAmmo = new SniperAmmo(ait, ammoAmount);
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = tempSnAmmo;
                    sniperAmmoTracker.Add(tempSnAmmo);
                    return;
                case (int) AmmoTypes.SMGAmmo:
                    SMGAmmo tempSMGAmmo = new SMGAmmo(ait, ammoAmount);
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = tempSMGAmmo;
                    smgAmmoTracker.Add(tempSMGAmmo);
                    return;
                case (int) AmmoTypes.RifleAmmo:
                    RifleAmmo tempRAmmo = new RifleAmmo(ait, ammoAmount);
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = tempRAmmo;
                    rifleAmmoTracker.Add(tempRAmmo);
                    return;
                case (int) AmmoTypes.HandcannonAmmo:
                    HandcannonAmmo tempHAmmo = new HandcannonAmmo(ait, ammoAmount);
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = tempHAmmo;
                    handcannonAmmoTracker.Add(tempHAmmo);
                    return;
                case(int) AmmoTypes.GrenadeLauncherAmmo:
                    GrenadeLauncherAmmo tempGLAmmo = new GrenadeLauncherAmmo(ait, ammoAmount);
                    playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = tempGLAmmo;
                    grenadeLauncherAmmoTracker.Add(tempGLAmmo);
                    return;
            }
        }

        /// <summary>
        /// Delete an ammo brick from the ammo list and it's inventory slot
        /// </summary>
        /// <param name="ammoType">The ammo type being removed</param>
        /// <param name="listPos">The position in the ammo list</param>
        /// <param name="ait">The position in the inventory</param>
        private void DeleteAmmo(int ammoType, int listPos, AmmoInventoryTracker ait)
        {
            //playerInventory.inventory[ait.inventoryRow][ait.inventoryColumn] = new ItemSO.EmptyItemSO();
            switch (ammoType)
            {
                case (int) AmmoTypes.PistolAmmo:
                    pistolAmmoTracker.Remove(pistolAmmoTracker[listPos]);
                    return;
                case (int) AmmoTypes.ShotgunAmmo:
                    shotgunAmmoTracker.Remove(shotgunAmmoTracker[listPos]);
                    return;
                case (int) AmmoTypes.SniperAmmo:
                    sniperAmmoTracker.Remove(sniperAmmoTracker[listPos]);
                    return;
                case (int) AmmoTypes.SMGAmmo:
                    smgAmmoTracker.Remove(smgAmmoTracker[listPos]);
                    return;
                case (int) AmmoTypes.RifleAmmo:
                    rifleAmmoTracker.Remove(rifleAmmoTracker[listPos]);
                    return;
                case (int) AmmoTypes.HandcannonAmmo:
                    handcannonAmmoTracker.Remove(handcannonAmmoTracker[listPos]);
                    return;
                case(int) AmmoTypes.GrenadeLauncherAmmo:
                    grenadeLauncherAmmoTracker.Remove(grenadeLauncherAmmoTracker[listPos]);
                    return;
            }
        }
    }
}
