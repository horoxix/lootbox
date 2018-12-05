﻿using System;
using System.Collections;
using System.Collections.Generic;
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
    FirebaseManager firebaseManager;
    private ItemFactory itemFactory;
    private WeaponFactory weaponFactory;

    private void Start()
    {
        itemFactory = new ConcreteItemFactory();
        weaponFactory = new ConcreteWeaponFactory();
        firebaseManager = FindObjectOfType<FirebaseManager>();
        if (!firebaseManager)
        {
            Debug.LogError(gameObject + " couldn't find FirebaseManager");
        }
    }

    // On click to OpenBox, looks at how many items are in the box and adds an Item.
    // TODO : In UI, add item to specific gameObjects.
    public void OpenBox(LootBox lootBox)
    {
        if(User.user.LootBoxes > 0)
        {
            for (int i = 0; i < lootBox.ItemCount; i++)
            {
                GameObject thisObject = lootManager.lootSlots[i].gameObject;
                Image uiSprite = thisObject.GetComponent<Image>();
                ClearItemSprites(thisObject);
                StartCoroutine(CreateLoot(thisObject, uiSprite));
            }
            User.user.Experience += lootBox.Experience;
            if (User.user.Experience >= User.user.ExperienceToNext)
            {
                LevelUp levelUp = new LevelUp();
                levelUp.levelUp(playerLevelText);
            }
            User.user.LootBoxes -= 1;
            UpdateLootBoxesText();
            firebaseManager.LootBoxes = User.user.LootBoxes;
            firebaseManager.UpdateLootBoxes();
            StartCoroutine(DisplayNames());
        }
        else
        {
            errorText.enabled = true;
            errorText.text = "You do not have any loot boxes!";
            StartCoroutine(DisableErrorText());
        }
    }

    private void AddItemToInventory(GameObject thisObject, Item item, Image uiSprite)
    {
        User.user.inventory.Add(item);
        uiSprite.sprite = GenerateRaritySprite(RaritySprites.raritySprites, item.rarity);
        uiSprite.enabled = true;
    }

    public IEnumerator DisplayNames()
    {
        yield return new WaitForSeconds(1.0f);
        for (int j = 0; j < User.user.inventory.Count; j++)
        {
            Debug.Log(User.user.inventory[j].itemName);
        }
    }

    public IEnumerator CreateLoot(GameObject thisObject, Image uiSprite)
    {
        Item item = CreateItem.Create();
        yield return new WaitForSeconds(0.5f);
        thisObject.GetComponent<Loot>().attachedItem = item;
        thisObject.GetComponent<Loot>().itemAttached = true;
        AddItemToInventory(thisObject, item, uiSprite);
        yield return new WaitForSeconds(0.5f);
    }

    public void ClearItemSprites(GameObject thisObject)
    {
        Transform itemSprite = thisObject.transform.GetChild(0);
        Transform buttonSprite = thisObject.transform.GetChild(1);
        Image childImage = itemSprite.GetComponent<Image>();
        childImage.enabled = false;
        buttonSprite.gameObject.SetActive(false);
        thisObject.GetComponent<Image>().enabled = false;
    }

    public Item.ItemType GenerateItemType()
    {
        Item.ItemType itemType = (Item.ItemType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Item.ItemType)).Length);
        return itemType;
    }

    public Weapon.WeaponType GenerateWeaponType()
    {
        Weapon.WeaponType weaponType = (Weapon.WeaponType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Weapon.WeaponType)).Length);
        return weaponType;
    }

    protected Sprite GenerateRaritySprite(Dictionary<string, Sprite> dict, Item.Rarity rarity)
    {
        switch (rarity)
        {
            case Item.Rarity.COMMON:
                return dict["Common"];
            case Item.Rarity.UNCOMMON:
                return dict["Uncommon"];
            case Item.Rarity.RARE:
                return dict["Rare"];
            case Item.Rarity.EPIC:
                return dict["Epic"];
            case Item.Rarity.LEGENDARY:
                return dict["Legendary"];
        }
        throw new NotImplementedException();
    }
    
    IEnumerator DisableErrorText()
    {
        yield return new WaitForSeconds(2.0f);
        errorText.enabled = false;
    }

    public void DebugAddLootBox()
    {
        User.user.LootBoxes += 1;
        firebaseManager.LootBoxes = User.user.LootBoxes;
        firebaseManager.UpdateLootBoxes();
        UpdateLootBoxesText();
    }

    private void UpdateLootBoxesText()
    {
        lootBoxesText.text = User.user.LootBoxes.ToString();
    }
}
