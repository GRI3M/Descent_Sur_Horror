using UnityEngine;
using ItemScripts.AmmoManagementScript;

namespace ItemScripts.AmmoScript
{
    /// <summary>
    /// Generic Ammo Brick class that is inhereted by every ammo type
    /// </summary>
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

    /// <summary>
    /// Different Ammo Types that are used for different weapons
    /// </summary>
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

    /// <summary>
    /// Ammo Brick for pistol ammo
    /// </summary>
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

    /// <summary>
    /// Ammo brick for Shotguns
    /// </summary>
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

    /// <summary>
    /// Ammo brick for SMGs
    /// </summary>
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

    /// <summary>
    /// Ammo brick for Rifles
    /// </summary>
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

    /// <summary>
    /// Ammo brick for snipers
    /// </summary>
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

    /// <summary>
    /// Ammo brick for handcannons
    /// </summary>
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

    /// <summary>
    /// Ammo brick for grenade launcers
    /// </summary>
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

    /// <summary>
    /// Return Error Ammo if there is an issue getting Ammo from a method with an ammo return
    /// </summary>
    public class ErrorAmmo : Ammo
    {
        public ErrorAmmo()
        {
            ammoName = "This is a Error";
            ammoType = -1;
        }
    }

    /// <summary>
    /// Tracks where in the inventory a ammo brick resides
    /// </summary>
    public class AmmoInventoryTracker : MonoBehaviour
    {
        public int inventoryRow;
        public int inventoryColumn;

        public AmmoInventoryTracker(int ir, int ic)
        {
            inventoryRow = ir;
            inventoryColumn = ic;
        }
    }
}

