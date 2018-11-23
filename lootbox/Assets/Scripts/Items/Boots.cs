using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : Item {

    public Boots(ItemType itemType, Rarity rarity, Sprite itemSprite, string itemName)
    {
        this.itemType = itemType ;
        this.itemSprite = itemSprite;
        this.rarity = rarity;
        this.itemName = itemName;
    }
}
