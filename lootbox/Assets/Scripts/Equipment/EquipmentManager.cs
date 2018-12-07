using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour {

    public List<GameObject> equipmentSlots;
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
    [SerializeField]
    public Image itemBackground;

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
    public CanvasGroup canvasGroup;

    // Use this for initialization
    void Start()
    {
        SetEquipmentSlots();
        SetPlayerDataText();
        SetModifierSlots();
        AttachItems();
        SetSprites();
        SetBackground();
    }


    void SetModifierSlots()
    {
        modifierSlots.Add(modifier1Text);
        modifierSlots.Add(modifier2Text);
        modifierSlots.Add(modifier3Text);
        modifierSlots.Add(modifier4Text);
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
            if(attachedItem != null)
            {
                image.enabled = true;
                image.sprite = attachedItem.itemBackground;
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

    // Fades alpha in or out for an image.
    public IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = canvasGroup.alpha;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            canvasGroup.alpha = Mathf.Lerp(alpha, aValue, t);
            yield return null;
        }
    }

    public void ToggleCanvas(int value)
    {
        StartCoroutine(FadeTo(value, 1));
        canvasGroup.interactable = !canvasGroup.interactable;
        canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
    }

    public void SelectItem(Item attachedItem)
    {
        DisableModifierText();
        itemNameText.text = "Name: " + attachedItem.itemName.ToString();
        itemRarityText.text = "Rarity: " + attachedItem.rarity.ToString();
        itemKeywordText.text = "Keyword: " + attachedItem.keyword.ToString();
        itemLevelText.text = "iLevel: " + attachedItem.ItemLevel.ToString();
        itemSprite.sprite = attachedItem.itemSprite;
        itemBackground.sprite = attachedItem.itemBackground;
        for (int i = 0; i < attachedItem.statCount; i++)
        {
            Text text = modifierSlots[i].GetComponent<Text>();
            text.enabled = true;
            text.text = attachedItem.modifierList[i].StatName + " : " + attachedItem.modifierList[i].StatValue;
        }
    }

    private void DisableModifierText()
    {
        for (int i = 0; i < modifierSlots.Count; i++)
        {
            modifierSlots[i].GetComponent<Text>().enabled = false;
        }
    }
}
