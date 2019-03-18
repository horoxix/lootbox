using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour {

    public List<GameObject> equipmentSlots;
    public List<Text> modifierSlots;
    [SerializeField]
    public Animator animator;
    public bool ModalShown;

    // Modal objects.
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
    [SerializeField]
    public CanvasGroup canvasGroup;

    // Player objects.
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

    // Equipment objects.
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

    // Assigns item modifier slots.
    void SetModifierSlots()
    {
        modifierSlots.Add(modifier1Text);
        modifierSlots.Add(modifier2Text);
        modifierSlots.Add(modifier3Text);
        modifierSlots.Add(modifier4Text);
        modifierSlots.Add(modifier5Text);
    }
    
    // Checks if item exists in slot.
    public ItemObject CheckForExists(ItemObject userItem)
    {
        if (userItem != null)
        {
            return userItem;
        }
        else
        {
            return null;
        }
    }

    // Returns specific sprite.
    public Sprite EquipmentSprite(ItemObject userItem, string itemTypeString)
    {
        if(CheckForExists(userItem) != null) {
            return userItem.itemSprite;
        } else
        {
            return EquipmentSprites.equipmentSprites[itemTypeString];
        }
    }

    // Sets sprites based on attached item.
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

    // Attaches items to slots based on equipped item.
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

    // Updates player data text based on equipped items.
    void SetPlayerDataText()
    {
        playerNameText.text = "Name : " + User.user.PlayerName;
        playerLevelText.text = "Level : "  + User.user.Level.ToString();
        playerLuckAmountText.text = "Luck : "  + User.user.luck.StatValue.ToString();
        playerDexAmountText.text = "Dex : "  + User.user.dexterity.StatValue.ToString();
        playerIntAmountText.text = "Int : "  + User.user.intelligence.StatValue.ToString();
        playerStrAmountText.text = "Str : "  + User.user.strength.StatValue.ToString();
    }

    // Sets rarity backgrounds based on item's rarityBackground.
    void SetBackground()
    {
        foreach (Transform child in transform)
        {
            Image image = child.GetComponent<Image>();
            ItemObject attachedItem = child.GetComponent<EquipmentSlot>().attachedItem;
            if(attachedItem != null)
            {
                image.enabled = true;
                image.sprite = attachedItem.itemBackgroundSprite;
            }
        }
    }
    
    // Sets Equipment Slots.
    void SetEquipmentSlots()
    {
        foreach (Transform child in transform)
        {
            equipmentSlots.Add(child.gameObject);
        }
    }

    // Removes an item.
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

    // Toggles canvas between visible and invisible.
    public void ToggleCanvas(int value)
    {
        StartCoroutine(FadeTo(value, 1));
        canvasGroup.interactable = !canvasGroup.interactable;
        canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
    }

    // Selecting an item displays information about it.
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

    // Disables modifier text.
    private void DisableModifierText()
    {
        for (int i = 0; i < modifierSlots.Count; i++)
        {
            modifierSlots[i].GetComponent<Text>().enabled = false;
        }
    }
}
