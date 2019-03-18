using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Open : MonoBehaviour {
    [SerializeField]
    GameObject Loot;
    [SerializeField]
    LootManager lootManager;
    [SerializeField]
    Text playerLevelText;
    [SerializeField]
    Text errorText;
    [SerializeField]
    Text lootBoxesText;
    [SerializeField]
    Text ExperienceText;
    [SerializeField]
    ItemObjectDatabase itemObjectDatabase;
    FirebaseManager firebaseManager;
    [SerializeField]
    Sprite HeavySprite;
    [SerializeField]
    Sprite MediumSprite;
    [SerializeField]
    Sprite LightSprite;

    // Initializes everything needed for the script.
    private void Start()
    {
        firebaseManager = FindObjectOfType<FirebaseManager>();
        if (!firebaseManager)
        {
            Debug.LogError(gameObject + " couldn't find FirebaseManager");
        }
    }

    // On click to OpenBox, looks at how many items are in the box and adds an Item.
    public void OpenBox()
    {
        if (User.user.LootBoxes > 0)
        {
            LootBox lootBox = GenerateLootBox();
            if (User.user.inventory.Count + lootBox.ItemCount > User.user.InventorySlots)
            {
                errorText.enabled = true;
                errorText.text = "Your inventory is too full!";
                StartCoroutine(DisableErrorText());
                return;
            }
            for (int i = 0; i < lootBox.ItemCount; i++)
            {
                GameObject thisObject = lootManager.lootSlots[i].gameObject;
                ClearItemSprites(thisObject);
                CreateLoot(thisObject, thisObject.GetComponent<Image>());
            }
            User.user.Experience += lootBox.Experience;
            if (User.user.Experience >= User.user.ExperienceToNext)
            {
                LevelUp levelUp = new LevelUp();
                levelUp.IncreaseLevel(playerLevelText, firebaseManager);
            }
            if(User.user.LootBoxes == User.user.MaxLootBoxes)
            {
                firebaseManager.UpdateLastTimeOpenedLootBox();
            }
            User.user.LootBoxes -= 1;
            User.user.Experience += lootBox.Experience;
            firebaseManager.UpdateDatabaseValues();
        }
        else
        {
            errorText.enabled = true;
            errorText.text = "You do not have any more loot boxes!";
            StartCoroutine(DisableErrorText());
        }
        //DataManager.dataManager.Save();
    }

    // Adds an item to the User's inventory.
    private void AddItemToInventory(ItemObject item, Image uiSprite)
    {
        if(item.itemType == ItemObject.ItemType.WEAPON)
        {
            User.user.weapons.Add(item);
        }
        else
        {
            User.user.inventory.Add(item);
        }
        uiSprite.sprite = GenerateOrbRaritySprite(RaritySprites.raritySprites, item.rarity);
        uiSprite.enabled = true;
    }

    public void CreateLoot(GameObject lootSlotObject, Image uiSprite)
    {
        Loot loot = lootSlotObject.GetComponent<Loot>();
        loot.attachedItem = CreateItemObject.GenerateItemObject(
            CreateItemObject.Generate(
                itemObjectDatabase.ItemList[RandomManager.random.Next(
                    itemObjectDatabase.ItemList.Count)]));
        loot.itemAttached = true;
        AddItemToInventory(loot.attachedItem, uiSprite);
    }

    // Clears item sprites from the loot UI display.
    public void ClearItemSprites(GameObject thisObject)
    {
        Transform itemSprite = thisObject.transform.GetChild(0);
        Transform buttonSprite = thisObject.transform.GetChild(1);
        Image childImage = itemSprite.GetComponent<Image>();
        childImage.enabled = false;
        buttonSprite.gameObject.SetActive(false);
        thisObject.GetComponent<Image>().enabled = false;
    }

    // Generates the orb sprite based on rarity of the generated item.
    protected Sprite GenerateOrbRaritySprite(Dictionary<string, Sprite> dict, ItemObject.Rarity rarity)
    {
        switch (rarity)
        {
            case ItemObject.Rarity.COMMON:
                return dict["Common"];
            case ItemObject.Rarity.UNCOMMON:
                return dict["Uncommon"];
            case ItemObject.Rarity.RARE:
                return dict["Rare"];
            case ItemObject.Rarity.EPIC:
                return dict["Epic"];
            case ItemObject.Rarity.LEGENDARY:
                return dict["Legendary"];
        }
        throw new NotImplementedException();
    }
    
    // Disables error text message.
    IEnumerator DisableErrorText()
    {
        yield return new WaitForSeconds(2.0f);
        errorText.enabled = false;
    }

    // Adds loot boxes for debug purposes.
    public void DebugAddLootBox()
    {
        Debug.Log(JsonUtility.ToJson(User.user.equippedArmor));
        DataManager.dataManager.LoadInventory();
        User.user.LootBoxes += 1;
        firebaseManager.UpdateLootBoxes();
    }

    public LootBox GenerateLootBox()
    {
        LootBox.LootBoxType lootBoxTypeGenerated = (LootBox.LootBoxType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(LootBox.LootBoxType)).Length);
        return new LootBox(100, User.user.Level, User.user.Level / 10, 4, LootBox.LootType.FREE, lootBoxTypeGenerated, GetLootBoxImage(lootBoxTypeGenerated), GetLootBoxHealth(lootBoxTypeGenerated));
    }

    public Sprite GetLootBoxImage(LootBox.LootBoxType lootBoxType)
    {
        switch(lootBoxType)
        {
            case LootBox.LootBoxType.HEAVY:
                return HeavySprite;
            case LootBox.LootBoxType.MEDIUM:
                return MediumSprite;
            case LootBox.LootBoxType.LIGHT:
                return LightSprite;
            default:
                return LightSprite;
        }
    }

    public int GetLootBoxHealth(LootBox.LootBoxType lootBoxType)
    {
        switch (lootBoxType)
        {
            case LootBox.LootBoxType.HEAVY:
                return 200;
            case LootBox.LootBoxType.MEDIUM:
                return 150;
            case LootBox.LootBoxType.LIGHT:
                return 100;
            default:
                return 100;
        }
    }
}
