using ItemScripts.WeaponScripts;
using ItemScripts.WeaponScripts.GunScripts;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Pickups : MonoBehaviour
{
    
    const string PLAYER_STRING = "Player";

    public void PlayerPickupInteraction(EquippedItem equippedItem)
    {
        //if (other.CompareTag(PLAYER_STRING))
        // {
        //     EquippedItem equippedWeapon = other.GetComponentInChildren<EquippedItem>();
             OnPickUp(equippedItem);
             Destroy(this.gameObject);
        //}


    }
    protected abstract void OnPickUp(EquippedItem equippedWeapon);
}
