using ItemScripts.WeaponScripts;
using ItemScripts.WeaponScripts.GunScripts;
using Unity.VisualScripting;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;

    const string PLAYER_STRING = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            EquippedWeapon equippedWeapon = other.GetComponentInChildren<EquippedWeapon>();
            equippedWeapon.SwitchWeapon(weaponSO);
            Destroy(this.gameObject);
        }
    }
}
