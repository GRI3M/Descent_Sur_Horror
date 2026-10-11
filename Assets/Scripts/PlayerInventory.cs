using System;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {

        // The Max Inventory Size for the player. 24 slots are for the main inventory, and 3 slots are for weapons
        // that can go into the weapon satchel. The weapon satchel is a special inventory that can only hold weapons, and is not affected by the bag size.
        // Inventroy initializes as blocked and will refill to be empty on startup.
        private int[] Inventory = new int [27];

            // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
                BagResize((int)bagTypes.None);


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
                if(Inventory[i] == (int)survivorItems.Blocked)
                {
                    Inventory[i] = (int)survivorItems.Empty;
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
            if(bag==(int)bagTypes.None) end = 11;
            else if(bag==(int)bagTypes.Bag) end =15;
            else if(bag==(int)bagTypes.Upgrade1) end = 19;
            else if(bag==(int)bagTypes.Upgrade2) end = 23;
            for(int i=0;i<end;i++){
                if(Inventory[i] == (int)survivorItems.Blocked)
                {
                    Inventory[i] = (int)survivorItems.Empty;
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
        private int CheckAvailability(int Slot, int Item) 
        {
            int[] satchelSlots = {24,25,26};
            int[] bigWeapon = {(int)survivorItems.ShotgunPart1, (int)survivorItems.ShotgunPart2};

            if(Inventory[Slot] == (int)survivorItems.Blocked) return 0;

            else if(Inventory[Slot]==(int)survivorItems.Empty && !satchelSlots.Contains((int)Inventory[Slot]) && !bigWeapon.Contains(Item)) return 1;

            else if(satchelSlots.Contains((int)Inventory[Slot]) && Inventory[Slot] == (int)survivorItems.Empty ) return 1;


            else return -1;
        }



    }

}