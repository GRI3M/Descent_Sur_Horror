using ItemScripts;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    [Header("Item Values")]
    public string itemName;
    public int itemID;
    public int itemType;
    public Sprite icon;
    public bool equipable = false;
    public bool isStackable;
    public bool isDualSlot;
    public float movementSpeedModifier;

    public class EmptyItemSO : ItemSO
        {
            public EmptyItemSO()
            {
                itemName = "Empty";
                itemType = (int) Items.ItemTypes.Empty;
                equipable = true;
                movementSpeedModifier = 1.5f;
            }
        }
}
