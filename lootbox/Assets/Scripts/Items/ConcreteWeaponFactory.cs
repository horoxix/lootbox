using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteWeaponFactory : WeaponFactory {

    public override Weapon Create(Weapon.WeaponType weaponType, GameObject gameObject)
    {
        Item.Rarity rarity = GenerateRarity();
        Item.Keywords keyword = GenerateKeyword();
        Weapon weapon = gameObject.GetComponent<Weapon>();
        switch (weaponType)
        {
            case Weapon.WeaponType.SWORD:
                weapon.Init(Weapon.WeaponType.SWORD, rarity, GenerateWeaponSprite(ItemSprites.swordSprites, rarity), rarity + " " + keyword + " Sword");
                return weapon;
            case Weapon.WeaponType.MACE:
                weapon.Init(Weapon.WeaponType.MACE, rarity, GenerateWeaponSprite(ItemSprites.maceSprites, rarity), rarity + " " + keyword + " Mace");
                return weapon;
            case Weapon.WeaponType.BOW:
                weapon.Init(Weapon.WeaponType.BOW, rarity, GenerateWeaponSprite(ItemSprites.bowSprites, rarity), rarity + " " + keyword + " Bow");
                return weapon;
            case Weapon.WeaponType.AXE:
                weapon.Init(Weapon.WeaponType.AXE, rarity, GenerateWeaponSprite(ItemSprites.axeSprites, rarity), rarity + " " + keyword + " Axe");
                return weapon;
            case Weapon.WeaponType.SPEAR:
                weapon.Init(Weapon.WeaponType.SPEAR, rarity, GenerateWeaponSprite(ItemSprites.spearSprites, rarity), rarity + " " + keyword + " Spear");
                return weapon;
            default:
                Debug.Log("Weapon Type not found");
                break;
        }
        throw new System.NotImplementedException();
    }
}
