using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item", order = 1)]
[Serializable]
public class Item : ScriptableObject{
    public Rarity rarity;
    public Keywords keyword;
    public ItemType itemType;
    public string itemName = "Name";
    public string itemTypeName = "itemTypeName";
    public ItemNames itemNameList;
    [SerializeField]
    public Sprite itemSprite = null;
    public Sprite itemBackgroundSprite = null;
    public Dictionary<string, Sprite> itemSpriteList;
    public List<Stat> modifierList;
    public int value;
    public int statCount;
    public int ItemLevel;
    public bool equipped = false;

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
