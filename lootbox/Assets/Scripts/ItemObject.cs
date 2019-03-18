using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemObject {

    public Rarity rarity;
    public Keywords keyword;
    public ItemType itemType;
    public string itemName;
    public string itemTypeName;
    public ItemNames itemNameList;
    public Sprite itemSprite;
    public Sprite itemBackgroundSprite;
    public Dictionary<string, Sprite> itemSpriteList;
    public List<Stat> modifierList;
    public int value;
    public int statCount;
    public int itemLevel;
    public bool equipped = false;

    public ItemObject(Rarity rarity, Keywords keyword, ItemType itemType, string itemName, string itemTypeName, Sprite itemSprite, Sprite itemBackgroundSprite, List<Stat> modifierList, int value, int itemLevel, int statCount)
    {
        this.rarity = rarity;
        this.keyword = keyword;
        this.itemType = itemType;
        this.itemName = itemName;
        this.itemTypeName = itemTypeName;
        this.itemSprite = itemSprite;
        this.itemBackgroundSprite = itemBackgroundSprite;
        this.modifierList = modifierList;
        this.value = value;
        this.itemLevel = itemLevel;
        this.statCount = statCount;
    }

    // Enum list of possible Item Types.
    public enum ItemType
    {
        WEAPON,
        ARMOR,
        PANTS,
        BOOTS,
        HELM,
        BELT,
        ACCESSORY,
        GLOVES
    }

    // Enum list of possible Rarity values.
    public enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        EPIC,
        LEGENDARY,
    }

    // Enum list of possible Keywords.
    public enum Keywords
    {
        NORMAL,
        DAMAGED,
        RUSTY,
        MAGIC,
        PERFECT,
        EXQUISITE
    }

    public enum Modifier
    {
        LUCK,
        STRENGTH,
        DEXTERITY,
        INTELLIGENCE
    }
}

