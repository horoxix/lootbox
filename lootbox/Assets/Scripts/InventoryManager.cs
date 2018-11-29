using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    public List<GameObject> inventorySlots;

	// Use this for initialization
	void Start () {
        SetInventorySlots();
        SetBackground();
        SetSprites();

	}
	

    void SetSprites()
    {
        for (int i = 0; i < User.user.inventory.Count; i++)
        {
            Image image = inventorySlots[i].GetComponent<Image>();
            image.enabled = true;
            image.sprite = User.user.inventory[i].itemSprite;
        }
    }

    void SetBackground()
    {
        foreach (Transform child in transform)
        {
            Image image = child.GetComponent<Image>();
            image.enabled = true;
            Item attachedItem = child.GetComponent<InventorySlot>().attachedItem;
            switch (attachedItem.rarity)
            {
                case Item.Rarity.COMMON:
                    image.sprite = Resources.Load<Sprite>("rarity/common");
                    break;
                case Item.Rarity.UNCOMMON:
                    image.sprite = Resources.Load<Sprite>("rarity/uncommon");
                    break;
                case Item.Rarity.RARE:
                    image.sprite = Resources.Load<Sprite>("rarity/rare");
                    break;
                case Item.Rarity.EPIC:
                    image.sprite = Resources.Load<Sprite>("rarity/epic");
                    break;
                case Item.Rarity.LEGENDARY:
                    image.sprite = Resources.Load<Sprite>("rarity/legendary");
                    break;
            }
        }
    }

    void SetInventorySlots()
    {
        foreach (Transform child in transform)
        {
            inventorySlots.Add(child.gameObject);
            for (int i = 0; i < User.user.inventory.Count; i++)
            {
                child.GetComponent<InventorySlot>().attachedItem = User.user.inventory[i];
            }
        }
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
