using UnityEngine;
using ItemScripts.AmmoManagementScript;

namespace ItemScripts.AmmoScript
{
    ///This script might get reduced to remove ammoName, ammoType and drop amount
    /// so that these values can be replaced by SO scripts;


    /// <summary>
    /// Generic Ammo Brick class that is inhereted by every ammo type
    /// </summary>
    public class Ammo : Items
    {
        [Header("Ammo Attributes")]
        [SerializeField] public AmmoSO ammoSO;
        public int currentAmmo;
    

    
    // /// <summary>
    // /// Return Error Ammo if there is an issue getting Ammo from a method with an ammo return
    // /// </summary>
    // public class ErrorAmmo : Ammo
    // {
    //     public ErrorAmmo()
    //     {
    //         ammoName = "This is a Error";
    //         ammoType = -1;
    //     }
    // }
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
}

