using ItemScripts;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public int itemType;
    public bool equipable = false;
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
