using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour {

    public List<GameObject> equipmentSlots;

    [SerializeField]
    public Text playerNameText;
    [SerializeField]
    public Text playerLevelText;
    [SerializeField]
    public Text playerLuckAmountText;
    [SerializeField]
    public Text playerDexAmountText;
    [SerializeField]
    public Text playerIntAmountText;
    [SerializeField]
    public Text playerStrAmountText;

    [SerializeField]
    public EquipmentSlot HelmSlot;
    [SerializeField]
    public EquipmentSlot ArmorSlot;
    [SerializeField]
    public EquipmentSlot LeftHandSlot;
    [SerializeField]
    public EquipmentSlot RightHandSlot;
    [SerializeField]
    public EquipmentSlot Accessory1Slot;
    [SerializeField]
    public EquipmentSlot Accessory2Slot;
    [SerializeField]
    public EquipmentSlot BootsSlot;
    [SerializeField]
    public EquipmentSlot GlovesSlot;
    [SerializeField]
    public EquipmentSlot PantsSlot;
    [SerializeField]

    // Use this for initialization
    void Start()
    {
        SetEquipmentSlots();
        SetPlayerDataText();
        AttachItems();
        SetSprites();
        SetBackground();
    }

    public Item CheckForExists(Item userItem)
    {
        if(userItem != null)
        {
            return userItem;
        } else
        {
            Debug.Log("no equipped item");
            return null;
        }
    }

    public Sprite EquipmentSprite(Item userItem, string itemTypeString)
    {
        if(CheckForExists(userItem)) {
            return userItem.itemSprite;
        } else
        {
            return EquipmentSprites.equipmentSprites[itemTypeString];
        }
    }

    void SetSprites()
    {
        ArmorSlot.transform.GetChild(0).GetComponent<Image>().sprite = EquipmentSprite(ArmorSlot.attachedItem, "Armor");
        HelmSlot.transform.GetChild(0).GetComponent<Image>().sprite = EquipmentSprite(HelmSlot.attachedItem, "Helm");
        Accessory1Slot.transform.GetChild(0).GetComponent<Image>().sprite = EquipmentSprite(Accessory1Slot.attachedItem, "Accessory");
        Accessory2Slot.transform.GetChild(0).GetComponent<Image>().sprite = EquipmentSprite(Accessory2Slot.attachedItem, "Accessory");
        BootsSlot.transform.GetChild(0).GetComponent<Image>().sprite = EquipmentSprite(BootsSlot.attachedItem, "Boots");
        PantsSlot.transform.GetChild(0).GetComponent<Image>().sprite = EquipmentSprite(PantsSlot.attachedItem, "Pants");
        GlovesSlot.transform.GetChild(0).GetComponent<Image>().sprite = EquipmentSprite(GlovesSlot.attachedItem, "Gloves");
        LeftHandSlot.transform.GetChild(0).GetComponent<Image>().sprite = EquipmentSprite(LeftHandSlot.attachedItem, "Weapon");
        RightHandSlot.transform.GetChild(0).GetComponent<Image>().sprite = EquipmentSprite(RightHandSlot.attachedItem, "Weapon");
    }

    public void AttachItems()
    {
        HelmSlot.attachedItem = CheckForExists(User.user.equippedHelm);
        ArmorSlot.attachedItem = CheckForExists(User.user.equippedArmor);
        LeftHandSlot.attachedItem = CheckForExists(User.user.equippedLeftHand);
        RightHandSlot.attachedItem = CheckForExists(User.user.equippedRightHand);
        Accessory1Slot.attachedItem = CheckForExists(User.user.equippedAccessory1);
        Accessory2Slot.attachedItem = CheckForExists(User.user.equippedAccessory2);
        PantsSlot.attachedItem = CheckForExists(User.user.equippedPants);
        GlovesSlot.attachedItem = CheckForExists(User.user.equippedGloves);
        BootsSlot.attachedItem = CheckForExists(User.user.equippedBoots);
    }

    void SetPlayerDataText()
    {
        playerNameText.text = "Name : " + User.user.PlayerName;
        playerLevelText.text = "Level : "  + User.user.Level.ToString();
        playerLuckAmountText.text = "Luck : "  + User.user.luck.StatValue.ToString();
        playerDexAmountText.text = "Dex : "  + User.user.dexterity.StatValue.ToString();
        playerIntAmountText.text = "Int : "  + User.user.intelligence.StatValue.ToString();
        playerStrAmountText.text = "Str : "  + User.user.strength.StatValue.ToString();
    }

    void SetBackground()
    {
        foreach (Transform child in transform)
        {
            Image image = child.GetComponent<Image>();
            Item attachedItem = child.GetComponent<EquipmentSlot>().attachedItem;
            if (attachedItem != null)
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
            else
            {
                image.sprite = Resources.Load<Sprite>("background/basic");
            }
        }
    }
    

    void SetEquipmentSlots()
    {
        foreach (Transform child in transform)
        {
            equipmentSlots.Add(child.gameObject);
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
