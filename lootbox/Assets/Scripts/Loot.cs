using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Loot : MonoBehaviour {
    private Text currencyText;
    public Item attachedItem;
    private void Start()
    {
        currencyText = FindObjectOfType<Currency>().GetComponent<Text>();
    }

    // Removes Loot Image in UI
    public void RemoveImage()
    {
        Image image = gameObject.GetComponent<Image>();
        image.sprite = null;
        image.enabled = false;
        HideButtons();
    }

    // Destroys component of loot
    public void RemoveItem()
    {
        attachedItem = null;
    }

    // Hides disenchant and send to inventory buttons
    public void HideButtons()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Disenchants based on item's value and adds to user.currency
    public void Disenchant()
    {
        Item item = attachedItem;
        AssetDatabase.DeleteAsset("Assets/Data/" + attachedItem.name.ToString() + ".asset");
        User.user.Currency += item.value;
        currencyText.text = User.user.Currency.ToString();
        RemoveItem(item);
        RemoveImage();
        RemoveItem();
        HideButtons();
    }

    public void EmptySlot()
    {
        Item item = attachedItem;
        RemoveImage();
        RemoveItem();
    }

    private void OnMouseDown()
    {
        Image image = gameObject.GetComponent<Image>();
        image.sprite = attachedItem.itemSprite;
    }

    public void RemoveItem(Item itemToRemove)
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

}
