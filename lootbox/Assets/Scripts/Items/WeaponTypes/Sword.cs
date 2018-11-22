using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon {
    public Sword(WeaponType weaponType, Rarity rarity, Sprite itemSprite, string generatedName)
    {
        this.weaponType = weaponType;
        this.itemSprite = itemSprite;
        ItemRarity = rarity;
        this.generatedName = generatedName;
    }
}
