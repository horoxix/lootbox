using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteWeaponFactory : WeaponFactory {

    public override Weapon Create(Weapon.WeaponType weaponType)
    {
        Item.Rarity rarity = GenerateRarity();
        Item.Keywords keyword = GenerateKeyword();
        switch (weaponType)
        {
            case Weapon.WeaponType.SWORD:
                return new Sword(Weapon.WeaponType.SWORD, rarity, GenerateWeaponSprite(ItemSprites.swordSprites, rarity), rarity + " " + keyword + " Sword");
            case Weapon.WeaponType.MACE:
                return new Mace(Weapon.WeaponType.MACE, rarity, GenerateWeaponSprite(ItemSprites.maceSprites, rarity), rarity + " " + keyword + " Mace");
            case Weapon.WeaponType.BOW:
                return new Bow(Weapon.WeaponType.BOW, rarity, GenerateWeaponSprite(ItemSprites.bowSprites, rarity), rarity + " " + keyword + " Bow");
            case Weapon.WeaponType.AXE:
                return new Axe(Weapon.WeaponType.AXE, rarity, GenerateWeaponSprite(ItemSprites.axeSprites, rarity), rarity + " " + keyword + " Axe");
            case Weapon.WeaponType.SPEAR:
                return new Spear(Weapon.WeaponType.SPEAR, rarity, GenerateWeaponSprite(ItemSprites.spearSprites, rarity), rarity + " " + keyword + " Spear");
            default:
                Debug.Log("Weapon Type not found");
                break;
        }
        throw new System.NotImplementedException();
    }
}
