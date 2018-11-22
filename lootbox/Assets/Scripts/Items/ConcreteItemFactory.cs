using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteItemFactory : ItemFactory {

    public override Item GetItem(Item.ItemType itemType)
    {
        Item.Rarity rarity = GenerateRarity();
        Item.Keywords keyword = GenerateKeyword();
        switch (itemType)
        {
            case Item.ItemType.WEAPON:
                return new Weapon();
            case Item.ItemType.ARMOR:
                return new Armor(Item.ItemType.ARMOR, rarity, GenerateItemSprite(ItemSprites.armorSprites, rarity), rarity +  " " + keyword + " Armor");
            case Item.ItemType.BOOTS:
                return new Boots(Item.ItemType.BOOTS, rarity, GenerateItemSprite(ItemSprites.bootsSprites, rarity), rarity + " " + keyword + " Boots");
            case Item.ItemType.HELM:
                return new Helm(Item.ItemType.HELM, rarity, GenerateItemSprite(ItemSprites.helmSprites, rarity), rarity + " " + keyword + " Helm");
            case Item.ItemType.BELT:
                return new Belt(Item.ItemType.BELT, rarity, GenerateItemSprite(ItemSprites.beltsSprites, rarity), rarity + " " + keyword + " Belt");
            case Item.ItemType.ACCESSORY:
                return new Accessory(Item.ItemType.ACCESSORY, rarity, GenerateItemSprite(ItemSprites.accessorySprites, rarity), rarity + " " + keyword + " Accessory");
            case Item.ItemType.PANTS:
                return new Pants(Item.ItemType.PANTS, rarity, GenerateItemSprite(ItemSprites.pantsSprites, rarity), rarity + " " + keyword + " Pants");
            case Item.ItemType.GLOVES:
                return new Gloves(Item.ItemType.GLOVES, rarity, GenerateItemSprite(ItemSprites.glovesSprites, rarity), rarity + " " + keyword + " Gloves");
            default:
                Debug.Log("Item Type not found");
                break;
        }
        throw new System.NotImplementedException();
    }
}
