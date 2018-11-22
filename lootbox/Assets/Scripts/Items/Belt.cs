using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : Item {

    public Belt(ItemType itemType, Rarity rarity, Sprite itemSprite, string generatedName)
    {
        this.itemType = itemType;
        this.itemSprite = itemSprite;
        this.ItemRarity = rarity;
        this.generatedName = generatedName;
        this.ItemName = ItemName;
    }
}
