using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemObject attachedItem;
    private InventoryManager inventoryManager;

    // Highlights selected inventory slot object on click.
    private void OnMouseDown()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        inventoryManager.gameObject.GetComponent<Equip>().selectedItem = attachedItem;
        inventoryManager.SelectItem(attachedItem);
        GetComponent<Image>().color = Color.cyan;
    }
}
