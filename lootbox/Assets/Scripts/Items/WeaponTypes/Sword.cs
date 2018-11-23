using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon {
    public Sword(WeaponType weaponType, Rarity rarity, Sprite itemSprite, string itemName)
    {
        this.weaponType = weaponType;
        this.itemSprite = itemSprite;
        this.rarity = rarity;
        this.itemName = itemName;
    }
}
