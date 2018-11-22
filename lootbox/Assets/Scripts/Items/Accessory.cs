using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory : Item {

    public Accessory(ItemType itemType, Rarity rarity, Sprite itemSprite, string generatedName)
    {
        this.itemType = itemType;
        this.itemSprite = itemSprite;
        this.ItemRarity = rarity;
        this.generatedName = generatedName;
        this.ItemName = ItemName;
    }
}
