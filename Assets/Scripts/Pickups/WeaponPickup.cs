using ItemScripts.WeaponScripts;
using ItemScripts.WeaponScripts.GunScripts;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponPickup : Pickups
{
    [SerializeField] WeaponSO weaponSO;



    protected override void OnPickUp(EquippedWeapon equippedWeapon)
    {
        equippedWeapon.SwitchWeapon(weaponSO);       
    }
}
