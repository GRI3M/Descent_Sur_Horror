using UnityEngine;
using ItemScripts.AmmoManagement;
using JetBrains.Annotations;


public class AmmoDrop : MonoBehaviour
{
    [SerializeField] public GameObject ammoBlock;
    public int ammoCount;
    public int ammoType;

    public void CreateAmmoDrop()
    {
        float r = Random.Range(0f, 1);
    }
}
