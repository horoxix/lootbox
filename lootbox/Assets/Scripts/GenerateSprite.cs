using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSprite {

    public Dictionary<string, Sprite> GenerateSpriteList(Item.ItemType itemType)
    {
        
        switch(itemType)
        {
            case Item.ItemType.WEAPON:
                Weapon.WeaponType weaponType = (Weapon.WeaponType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Weapon.WeaponType)).Length);
                return GenerateWeaponSpriteList(weaponType);
            case Item.ItemType.ARMOR:
                return ItemSprites.armorSprites;
            case Item.ItemType.BOOTS:
                return ItemSprites.bootsSprites;
            case Item.ItemType.HELM:
                return ItemSprites.helmSprites;
            case Item.ItemType.BELT:
                return ItemSprites.beltsSprites;
            case Item.ItemType.ACCESSORY:
                return ItemSprites.accessorySprites;
            case Item.ItemType.PANTS:
                return ItemSprites.pantsSprites;
            case Item.ItemType.GLOVES:
                return ItemSprites.glovesSprites;
            default:
                Debug.Log("Item Type not found");
                break;
        }
        Debug.Log(itemType + " Not found");
        throw new NotImplementedException();
    }

    public Dictionary<string, Sprite> GenerateWeaponSpriteList(Weapon.WeaponType weaponType)
    {
        switch (weaponType)
        {
            case Weapon.WeaponType.SWORD:
                return ItemSprites.swordSprites;
            case Weapon.WeaponType.MACE:
                return ItemSprites.maceSprites;
            case Weapon.WeaponType.BOW:
                return ItemSprites.bowSprites;
            case Weapon.WeaponType.AXE:
                return ItemSprites.axeSprites;
            case Weapon.WeaponType.SPEAR:
                return ItemSprites.spearSprites;
        }
              Debug.Log(weaponType + " Not found");
              throw new NotImplementedException();
    }
}
