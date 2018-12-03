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
        DisableModifierText(inventoryManager);
        inventoryManager.itemNameText.text = "Name: " + attachedItem.itemName.ToString();
        inventoryManager.itemRarityText.text = "Rarity: " + attachedItem.rarity.ToString();
        inventoryManager.itemKeywordText.text = "Keyword: " + attachedItem.keyword.ToString();
        inventoryManager.itemLevelText.text = "iLevel: " + attachedItem.ItemLevel.ToString();
        inventoryManager.itemSprite.sprite = attachedItem.itemSprite;
        for(int i = 0; i < attachedItem.statCount; i ++)
        {
            Text text = inventoryManager.modifierSlots[i].GetComponent<Text>();
            text.enabled = true;
            text.text = attachedItem.modifierList[i].StatName + " : " + attachedItem.modifierList[i].StatValue;
        }
    }

    private void DisableModifierText(InventoryManager inventoryManager)
    {
        for(int i = 0; i < inventoryManager.modifierSlots.Count; i ++)
        {
            inventoryManager.modifierSlots[i].GetComponent<Text>().enabled = false;
        }
    }
}
