using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Loot : MonoBehaviour {
    private Text currencyText;
    public ItemObject attachedItem;
    public bool itemAttached;
    private void Start()
    {
        currencyText = FindObjectOfType<Currency>().GetComponent<Text>();
    }

    // Removes Loot Image in UI
    public void RemoveImage()
    {
        Image image = gameObject.GetComponent<Image>();
        Image childImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        childImage.sprite = null;
        image.sprite = null;
        childImage.enabled = false;
        image.enabled = false;
        HideButtons();
    }

    // Destroys component of loot
    public void RemoveAttachedItem()
    {
        attachedItem = null;
        itemAttached = false;
    }

    // Hides disenchant and send to inventory buttons
    public void HideButtons()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    // Disenchants based on item's value and adds to user.currency
    public void Disenchant()
    {
        ItemObject item = attachedItem;
        RemoveImage();
        HideButtons();
        //AssetDatabase.DeleteAsset("Assets/Data/" + attachedItem.name.ToString() + ".asset");
        RemoveAttachedItem();
        RemoveItem(item);
        User.user.Currency += item.value;
        currencyText.text = User.user.Currency.ToString();
    }

    public void EmptySlot()
    {
        ItemObject item = attachedItem;
        RemoveImage();
        RemoveAttachedItem();
    }

    private void OnMouseDown()
    {
        if (itemAttached)
        {
            Image image = gameObject.GetComponent<Image>();
            Transform itemSprite = gameObject.transform.GetChild(0);
            Transform buttons = gameObject.transform.GetChild(1);
            Image childImage = itemSprite.GetComponent<Image>();
            childImage.sprite = attachedItem.itemSprite;
            childImage.enabled = true;
            buttons.gameObject.SetActive(true);
            switch (attachedItem.rarity)
            {
                case ItemObject.Rarity.COMMON:
                    image.sprite = Resources.Load<Sprite>("rarityBackground/common");
                    break;
                case ItemObject.Rarity.UNCOMMON:
                    image.sprite = Resources.Load<Sprite>("rarityBackground/uncommon");
                    break;
                case ItemObject.Rarity.RARE:
                    image.sprite = Resources.Load<Sprite>("rarityBackground/rare");
                    break;
                case ItemObject.Rarity.EPIC:
                    image.sprite = Resources.Load<Sprite>("rarityBackground/epic");
                    break;
                case ItemObject.Rarity.LEGENDARY:
                    image.sprite = Resources.Load<Sprite>("rarityBackground/legendary");
                    break;
            }
        }
    }

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

}
