using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : Weapon {

    public Mace(WeaponType weaponType, Rarity rarity, Sprite itemSprite, string generatedName)
    {
        this.weaponType = weaponType;
        this.itemSprite = itemSprite;
        this.ItemRarity = rarity;
        this.generatedName = generatedName;
        this.ItemName = ItemName;
    }
}
