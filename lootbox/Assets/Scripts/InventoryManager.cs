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
