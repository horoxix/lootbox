using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemScriptableObject", order = 1)]
public class ItemScriptableObject : ScriptableObject
{
    public ItemObject.Rarity rarity;
    public ItemObject.Keywords keyword;
    public ItemObject.ItemType itemType;
    public string itemName = " ";
    public string itemTypeName = " ";
    public ItemNames itemNameList;
    public Sprite itemSprite = null;
    public Sprite itemBackgroundSprite = null;
    public List<Stat> modifierList;
    public int value;
    public int statCount;
    public int ItemLevel;
    public bool equipped = false;
}

