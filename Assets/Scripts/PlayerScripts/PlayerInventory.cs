using System;
using System.Linq;
using UnityEngine;
using ItemScripts;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {

        // The Max Inventory Size for the player. 24 slots are for the main inventory, and 3 slots are for weapons
        // that can go into the weapon satchel. The weapon satchel is a special inventory that can only hold weapons, and is not affected by the bag size.
        // Inventroy initializes as blocked and will refill to be empty on startup.
        // this might be public depending on the equip
        private Items[] inventory = new Items [27];

        private bool pistolObtained;
        public int pistolAmmo;
        private bool shotgunObtained;
        public int shotgunAmmo;
        private bool submachineGunObtained;
        public int submachineGunAmmo;
        private bool rifleObtained;
        public int rifleAmmo;
        private bool sniperObtained;
        public int sniperAmmo;
        private bool magnumObtained;
        public int magnumAmmo;
        private bool grenadeLauncherObtained;
        public int grenadeLauncherAmmo;

        public enum BagTypes  
        { 
            None,
            Bag,
            Upgrade1,
            Upgrade2
        }
        
        public enum InventoryCheckDisplay
        {
            Empty,
            Filled,
            Changeable,
            SlotCheckError = -1,
        }

            // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
                BagResize((int)BagTypes.None);


        }
            

            // Update is called once per frame
        void Update()
        {
            
        }

        /// <summary>
        /// This function is called when the player obtains a weapon satchel. It will unlock the 3 slots in the inventory that are reserved for weapons, allowing the player to store weapons in those slots.
        /// The weapon satchel can only hold weapons that are at least 2 units in size.
        /// </summary>
        private void WeaponSatchelObtained()
        {
            for(int i = 24; i < 27; i++)
            {
                if(inventory[i].itemType == (int)Items.ItemTypes.Blocked)
                {
                    inventory[i].itemType = (int)Items.ItemTypes.Empty;
                }
            }
        }

        /// <summary>
        /// Resize the palyer's inventory on start up to default size, or when player obtains a new bag.
        /// </summary>
        /// <param name="bag"> The type of bag obtained by the player</param>
        private void BagResize(int bag)
        {
            int end = 11;
            if(bag==(int)BagTypes.None) end = 11;
            else if(bag==(int)BagTypes.Bag) end =15;
            else if(bag==(int)BagTypes.Upgrade1) end = 19;
            else if(bag==(int)BagTypes.Upgrade2) end = 23;
            for(int i=0;i<end;i++){
                if((int)inventory[i].itemType == (int)Items.ItemTypes.Blocked)
                {
                    inventory[i].itemType = (int)Items.ItemTypes.Empty;
                }
            }
        }

        /// <summary>
        /// Checks the current inventory slot player is trying to move an item into and checks if the item can be placed in that slot. Returns 1 if the item can be placed, 0 if the slot is blocked,
        /// 2 if there is currently an item in that slot but could replace that item, and 3 if there is an item there but it cannot be moved.
        /// and -1 if there is an unknown error.
        /// </summary>
        /// <param name="Slot">Checks which slot the player is trying to move an item into</param>
        /// <param name="Item">The item the player is trying to move</param>
        /// <returns></returns>
        private int CheckAvailability(int slot, int item) 
        {
             int[] satchelSlots = {24,25,26};
            //int[] bigWeapon = {(int)survivorItems.ShotgunPart1, (int)survivorItems.ShotgunPart2};

            if(inventory[slot].itemType == (int) Items.ItemTypes.Blocked) return (int)InventoryCheckDisplay.Empty;

            //else if(Inventory[Slot].itemType == (int)Items.ItemTypes.Empty && !satchelSlots.Contains((int)Inventory[Slot].itemType) && !bigWeapon.Contains(Item)) return (int)InventoryCheckDisplay.Empty;

            else if(satchelSlots.Contains((int)inventory[slot].itemType) && inventory[slot].itemType == (int)Items.ItemTypes.Empty ) return (int)InventoryCheckDisplay.Empty;


            else return (int)InventoryCheckDisplay.SlotCheckError;
        }

        /// <summary>
        /// Checks if the inventory is full
        /// </summary>
        public void CheckInventoryFull()
        {
            
        }

        /// <summary>
        /// Will check to see if a certain ammo type is currently allowed to drop
        /// </summary>
        public void CheckWeaponAmmoType()
        {
            
        }

        /// <summary>
        /// Checks to see if you can quick add an item into your inventory
        /// if you can't it should give the player a message that you cannot pick it up
        /// so that when you try again, it opens your inventory so you can try to add it.
        /// </summary>
        /// <param name="item"></param>
        public void QuickAdd(int item)
        {
            
        }

        /*private bool CheckSlot2(int Slot1)//Could drag in slot 2 as well, might be more efficient but we'll see
        {
            int Slot2 = 0;
            if(CheckAvailability(Slot1, (int)Inventory[Slot1].itemType) == (int)InventoryCheckDisplay.Empty) return true;
                //This needs to converse with the ui to see if the 2 part item is faced to the right or down.
                if(InventoryItem.PointedRight()) 
                    Slot2 = Slot1 + 1;
                    if(CheckAvailability(Slot2, (int)Inventory[Slot2].itemType) == (int)InventoryCheckDisplay.Empty) return true;
                else 
                    Slot2 = Slot1 + 4;
                    if(CheckAvailability(Slot2, (int)Inventory[Slot2].itemType) == (int)InventoryCheckDisplay.Empty) return true;


                
            else return false;
        }*/



    }

}