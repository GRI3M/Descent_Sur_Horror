using ItemScripts.WeaponScripts;
using ItemScripts.WeaponScripts.GunScripts;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponPickup : Pickups
{
    [SerializeField] WeaponSO weaponSO;



    protected override void OnPickUp(EquippedItem equippedWeapon)
    {
        equippedWeapon.SwitchWeapon(weaponSO);       
    }
}
