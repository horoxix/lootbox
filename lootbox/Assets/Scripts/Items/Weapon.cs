using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {
    public WeaponType weaponType;
    protected Luck luck;
    protected Strength strength;
    protected Dexterity dexterity;
    protected Intelligence intelligence;

    public enum WeaponType
    {
        SWORD,
        MACE,
        BOW,
        AXE,
        SPEAR
    }

    public void Instantiate(WeaponType weaponType, Rarity rarity, Sprite itemSprite, string itemName)
    {
        this.weaponType = weaponType;
        this.itemSprite = itemSprite;
        this.rarity = rarity;
        this.itemName = itemName;
    }
}
