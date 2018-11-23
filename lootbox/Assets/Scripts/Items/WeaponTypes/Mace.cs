using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : Weapon {

    public Mace(WeaponType weaponType, Rarity rarity, Sprite itemSprite, string itemName)
    {
        this.weaponType = weaponType;
        this.itemSprite = itemSprite;
        this.rarity = rarity;
        this.itemName = itemName;
    }
}
