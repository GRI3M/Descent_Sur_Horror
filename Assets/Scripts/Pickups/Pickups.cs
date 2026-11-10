using ItemScripts.WeaponScripts;
using ItemScripts.WeaponScripts.GunScripts;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Pickups : MonoBehaviour
{
    
    const string PLAYER_STRING = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            EquippedItem equippedWeapon = other.GetComponentInChildren<EquippedItem>();
            OnPickUp(equippedWeapon);
            Destroy(this.gameObject);
        }
    }
    protected abstract void OnPickUp(EquippedItem equippedWeapon);
}
