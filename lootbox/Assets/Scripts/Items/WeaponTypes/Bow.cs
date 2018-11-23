using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon {
    public Bow(WeaponType weaponType, Rarity rarity, Sprite itemSprite, string itemName)
    {
        this.weaponType = weaponType;
        this.itemSprite = itemSprite;
        this.rarity = rarity;
        this.itemName = itemName;
    }
}
