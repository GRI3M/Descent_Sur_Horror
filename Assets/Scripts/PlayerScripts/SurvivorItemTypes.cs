using UnityEngine;

namespace Player
{
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum survivorItems {
    Blocked,
    Empty,
    ShotgunPart1,
    ShotgunPart2,
    ShotgunAmmo,
    Pistol,
    PistolAmmo,
    SubmachineGun,
    SubmachineGunAmmo,

    }

    public enum bagTypes  
    { 
        None,
        Bag,
        Upgrade1,
        Upgrade2
    }
    
    public enum IventoryCheckDisplay
    {
        Empty,
        Filled,
        Changeable,
        SlotCheckError = -1,
    }
}
