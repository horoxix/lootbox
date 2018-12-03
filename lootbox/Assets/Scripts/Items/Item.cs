using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item", order = 1)]
public class Item : ScriptableObject{
    public Rarity rarity;
    public Keywords keyword;
    public ItemType itemType;
    public string itemName = "Name";
    public string itemTypeName = "itemTypeName";
    [SerializeField]
    public Sprite itemSprite = null;
    public Dictionary<string, Sprite> itemSpriteList;
    public int value = 100;
    public int statCount;
    public ItemNames itemNameList;
    public int ItemLevel;
    public List<Stat> modifierList;

    private void OnEnable()
    {
        
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

    public void Init(ItemType itemType, Rarity rarity, Sprite itemSprite, string itemName, int statCount)
    {
        this.itemType = itemType;
        this.itemSprite = itemSprite;
        this.rarity = rarity;
        this.itemName = itemName;
        this.value = 100;
        this.statCount = statCount;
    }
}
