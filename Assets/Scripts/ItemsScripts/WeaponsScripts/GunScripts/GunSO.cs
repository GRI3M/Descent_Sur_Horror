using UnityEngine;


[CreateAssetMenu(fileName = "GunSO", menuName = "Scriptable Objects/GunSO")]
public class GunSO : ScriptableObject
{
    [SerializeField]public int capacity;
    [SerializeField]public int currentAmmo;
    [SerializeField]public float reloadSpeed;
    [SerializeField]public float fireRate;
    [SerializeField]public bool automatic = false;
    [SerializeField]public int gunType;
    [SerializeField]public float accuracy;
    [SerializeField]public float accuracyUnscoped;

    [SerializeField]public GameObject hitVFX;
}

