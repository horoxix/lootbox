using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    public List<GameObject> inventorySlots;
    public List<Text> modifierSlots;
    [SerializeField]
    public Transform prefab;
    [SerializeField]
    public Text itemNameText;
    [SerializeField]
    public Text itemLevelText;
    [SerializeField]
    public Text itemRarityText;
    [SerializeField]
    public Text itemKeywordText;
    [SerializeField]
    public Text modifier1Text;
    [SerializeField]
    public Text modifier2Text;
    [SerializeField]
    public Text modifier3Text;
    [SerializeField]
    public Text modifier4Text;
    [SerializeField]
    public Text modifier5Text;
    [SerializeField]
    public Image itemSprite;
    [SerializeField]
    public Image itemBackground;

    // Use this for initialization
    void Start () {
        GenerateInventorySlots();
        SetInventorySlots();
        SetModifierSlots();
        SetItemSprites();
        SelectItem(inventorySlots[0].GetComponent<InventorySlot>().attachedItem);
    }
	
    // Sets the sprites to be equal to the items in the player's inventory
    void SetItemSprites()
    {
        for (int i = 0; i < User.user.inventory.Count; i++)
        { 
            inventorySlots[i].GetComponent<InventorySlot>().attachedItem = User.user.inventory[i];
            Image itemImage = inventorySlots[i].transform.GetChild(0).GetComponent<Image>();
            Image backgroundImage = inventorySlots[i].GetComponent<Image>();
            itemImage.enabled = true;
            backgroundImage.enabled = true;
            itemImage.sprite = inventorySlots[i].GetComponent<InventorySlot>().attachedItem.itemSprite;
            backgroundImage.sprite = inventorySlots[i].GetComponent<InventorySlot>().attachedItem.itemBackgroundSprite;
        }
    }

    // Instantiates inventory slots based on User.user.InventorySlots
    void GenerateInventorySlots()
    {
        for(int i=0; i < User.user.InventorySlots; i++)
        {
            Instantiate(prefab, transform);
        }
    }
    
    // Adds all inventory slots to a list of inventory slots.
    void SetInventorySlots()
    {
        foreach (Transform child in transform)
        {
            inventorySlots.Add(child.gameObject);
        }
    }

    // Adds all modifier text objects to the modifierSlots list.
    void SetModifierSlots()
    {
        modifierSlots.Add(modifier1Text);
        modifierSlots.Add(modifier2Text);
        modifierSlots.Add(modifier3Text);
        modifierSlots.Add(modifier4Text);
        modifierSlots.Add(modifier5Text);
    }

    // Removes an item from inventory.
    public void RemoveItem(ItemObject itemToRemove)
    {
        for (int i = 0; i < User.user.inventory.Count; i++)
        {
            if (User.user.inventory[i] == itemToRemove)
            {
                User.user.inventory.Remove(itemToRemove);
                return;
            }
        }
    }

    // Selects an item from the inventory.
    // TODO : Highlight selected item.
    public void SelectItem(ItemObject attachedItem)
    {
        DisableModifierText();
        itemNameText.text = "Name: " + attachedItem.itemName.ToString();
        itemRarityText.text = "Rarity: " + attachedItem.rarity.ToString();
        itemKeywordText.text = "Keyword: " + attachedItem.keyword.ToString();
        itemLevelText.text = "iLevel: " + attachedItem.itemLevel.ToString();
        itemSprite.sprite = attachedItem.itemSprite;
        itemBackground.sprite = attachedItem.itemBackgroundSprite;
        for (int i = 0; i < attachedItem.statCount; i++)
        {
            Text text = modifierSlots[i].GetComponent<Text>();
            text.enabled = true;
            text.text = attachedItem.modifierList[i].StatName + " : " + attachedItem.modifierList[i].StatValue;
        }
    }

    // Disables all modifier text.
    private void DisableModifierText()
    {
        for (int i = 0; i < modifierSlots.Count; i++)
        {
            modifierSlots[i].GetComponent<Text>().enabled = false;
        }
    }
}
