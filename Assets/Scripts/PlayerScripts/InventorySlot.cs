using UnityEngine;
using ItemScripts;
using Unity.VisualScripting;
public class InventorySlot : MonoBehaviour
{
    public Items slotItem;

    public int quantity;

    public InventorySlot(Items item, int quantity)
    {
        slotItem = item;
        this.quantity = quantity;
    }

    public bool IsEmpty()
    {
        return slotItem == null || quantity <= 0;
    }

    public void ClearSlot()
    {
        slotItem = null;
        quantity = 0;
    }

    public void SetItem(Items item, int quantity)
    {
        slotItem = item;
        this.quantity = quantity;
    }
}
