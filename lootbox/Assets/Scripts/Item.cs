using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    protected Rarity rarity;
    protected Keywords keyword;
    protected ItemType itemType;

    // Enum list of possible Item Types.
    protected enum ItemType
    {
        RIGHT_HAND,
        LEFT_HAND,
        ARMOR,
        PANTS,
        BOOTS,
        HELM,
        BELT,
        ACCESSORY
    }

    // Enum list of possible Rarity values.
    protected enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        EPIC,
        LEGENDARY
    }

    // Enum list of possible Keywords.
    protected enum Keywords
    {
        MAGIC,
        RUSTY,
        DAMAGED,
        PERFECT,
        EXQUISITE
    }

    // Randomly sets the values of the item based on the enums.
	void Start () {
        rarity = (Rarity)Random.Range(0, 4);
        keyword = (Keywords)Random.Range(0, 4);
        itemType = (ItemType)Random.Range(0, 7);
	}
}
