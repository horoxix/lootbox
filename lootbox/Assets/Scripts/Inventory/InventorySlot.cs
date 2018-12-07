using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item attachedItem;
    private InventoryManager inventoryManager;

    private void OnMouseDown()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        inventoryManager.gameObject.GetComponent<Equip>().selectedItem = attachedItem;
        inventoryManager.SelectItem(attachedItem);
    }
}
