using ItemScripts.WeaponScripts.GunScripts;
using UnityEngine;

public class AmmoPickups : Pickups
{
    /// <summary>
    /// Future update to instead have this on pickup method refer to the inventory
    /// and when you interact with ammo, it will quickly find a free inventory slot 
    /// to store that ammo
    /// </summary>
    [SerializeField] int ammoAmount = 100;
    protected override void OnPickUp(EquippedWeapon equippedWeapon)
    {
        equippedWeapon.UpdateAmmo(ammoAmount);
    }
}
