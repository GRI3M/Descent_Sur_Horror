using ItemScripts;
using UnityEngine;

[CreateAssetMenu(fileName = "UtilitySO", menuName = "Scriptable Objects/UtilitySO")]
public class UtilitySO : ItemSO
{
    [Header("Utility Identification")]
    public UtilityTypes utilityType;

    [Header("Utility Attributes")]
    public int maxUtilityCount;

    protected virtual void OnEnable()
    {
        itemType = ItemTypes.Utility;
        isStackable = true;
        equipable = true;
    }


}
