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
            EquippedWeapon equippedWeapon = other.GetComponentInChildren<EquippedWeapon>();
            OnPickUp(equippedWeapon);
            Destroy(this.gameObject);
        }
    }
    protected abstract void OnPickUp(EquippedWeapon equippedWeapon);
}
