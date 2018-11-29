using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    public List<GameObject> inventorySlots;

	// Use this for initialization
	void Start () {
        SetInventorySlots();
        SetSprites();
        SetBackground();
	}
	
    void SetSprites()
    {
        for (int i = 0; i < User.user.inventory.Count; i++)
        {
            Image image = inventorySlots[i].transform.GetChild(0).GetComponent<Image>();
            image.enabled = true;
            image.sprite = User.user.inventory[i].itemSprite;
            inventorySlots[i].GetComponent<InventorySlot>().attachedItem = User.user.inventory[i];
        }
    }

    void SetBackground()
    {
        foreach (Item item in User.user.inventory)
        {
            foreach (Transform child in transform)
            {
                Image image = child.GetComponent<Image>();
                Item attachedItem = child.GetComponent<InventorySlot>().attachedItem;
                if(attachedItem != null)
                {
                    image.enabled = true;
                    switch (attachedItem.rarity)
                    {
                        case Item.Rarity.COMMON:
                            image.sprite = Resources.Load<Sprite>("rarityBackground/common");
                            break;
                        case Item.Rarity.UNCOMMON:
                            image.sprite = Resources.Load<Sprite>("rarityBackground/uncommon");
                            break;
                        case Item.Rarity.RARE:
                            image.sprite = Resources.Load<Sprite>("rarityBackground/rare");
                            break;
                        case Item.Rarity.EPIC:
                            image.sprite = Resources.Load<Sprite>("rarityBackground/epic");
                            break;
                        case Item.Rarity.LEGENDARY:
                            image.sprite = Resources.Load<Sprite>("rarityBackground/legendary");
                            break;
                    }
                }
            }
        }
    }

    void SetInventorySlots()
    {
        foreach (Transform child in transform)
        {
            inventorySlots.Add(child.gameObject);
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
