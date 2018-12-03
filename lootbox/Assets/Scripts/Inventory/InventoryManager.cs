using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    public List<GameObject> inventorySlots;
    public List<Text> modifierSlots;
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
    public Image itemSprite;

    // Use this for initialization
    void Start () {
        SetInventorySlots();
        SetModifierSlots();
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

    void SetModifierSlots()
    {
        modifierSlots.Add(modifier1Text);
        modifierSlots.Add(modifier2Text);
        modifierSlots.Add(modifier3Text);
        modifierSlots.Add(modifier4Text);
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
