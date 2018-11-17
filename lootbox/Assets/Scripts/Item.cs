using System;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    private string itemName;
    protected Rarity rarity;
    protected Keywords keyword;
    protected ItemType itemType;
    protected RandomManager randomManager;
    public static List<Item> itemTypeList = new List<Item>()
{
    new Weapon(),
    new Helm(),
    new Pants(),
    new Gloves(),
    new Boots(),
    new Belt(),
    new Accessory(),
    new Armor()
};

    public string ItemName
    {
        get
        {
            return itemName;
        }

        set
        {
            itemName = value;
        }
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
    protected enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        EPIC,
        LEGENDARY,
        UNIQUE
    }

    // Enum list of possible Keywords.
    protected enum Keywords
    {
        NORMAL,
        DAMAGED,
        RUSTY,
        MAGIC,
        PERFECT,
        EXQUISITE
    }

    // Randomly sets the values of the item based on the enums.
	protected virtual void Start () {
        randomManager = FindObjectOfType<RandomManager>();
        keyword = (Keywords)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.CumulativeProbability));
        rarity = (Rarity)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.CumulativeProbability));
        ItemName = keyword + " " + itemType;
        Debug.Log("Generated " + ItemName + " " + rarity); 
	}

    // Debug purposes. Logs all time/key pairs for animationCurve.
    private void DebugLogKeys()
    {
        for (int i = 0; i < randomManager.CumulativeProbability.keys.Length; i++)
        {
            Debug.Log("Time: " + randomManager.CumulativeProbability.keys[i].time);
            Debug.Log("Key: " + randomManager.CumulativeProbability.keys[i].value);
        }
    }

}
