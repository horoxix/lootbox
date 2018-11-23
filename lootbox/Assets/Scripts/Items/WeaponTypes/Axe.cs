﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon {
    public Axe(WeaponType weaponType, Rarity rarity, Sprite itemSprite, string itemName)
    {
        this.weaponType = weaponType;
        this.itemSprite = itemSprite;
        this.rarity = rarity;
        this.itemName = itemName;
    }
}
