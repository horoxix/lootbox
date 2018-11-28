using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteItemFactory : ItemFactory {

    public override Item GetItem(Item.ItemType itemType, GameObject gameObject)
    {
        Item.Rarity rarity = GenerateRarity();
        Item.Keywords keyword = GenerateKeyword();
        Item item = gameObject.GetComponent<Item>();
        StatFactory statFactory = new ConcreteStatFactory();

        switch (itemType)
        {
            case Item.ItemType.ARMOR:
                item.Init(Item.ItemType.ARMOR, rarity, GenerateItemSprite(ItemSprites.armorSprites, rarity), rarity + " " + keyword + " Armor", statFactory.GenerateStatAmount(rarity));
                return item;
            case Item.ItemType.BOOTS:
                item.Init(Item.ItemType.BOOTS, rarity, GenerateItemSprite(ItemSprites.bootsSprites, rarity), rarity + " " + keyword + " Boots", statFactory.GenerateStatAmount(rarity));
                return item;
            case Item.ItemType.HELM:
                item.Init(Item.ItemType.HELM, rarity, GenerateItemSprite(ItemSprites.helmSprites, rarity), rarity + " " + keyword + " Helm", statFactory.GenerateStatAmount(rarity));
                return item;
            case Item.ItemType.BELT:
                item.Init(Item.ItemType.BELT, rarity, GenerateItemSprite(ItemSprites.beltsSprites, rarity), rarity + " " + keyword + " Belt", statFactory.GenerateStatAmount(rarity));
                return item;
            case Item.ItemType.ACCESSORY:
                item.Init(Item.ItemType.ACCESSORY, rarity, GenerateItemSprite(ItemSprites.accessorySprites, rarity), rarity + " " + keyword + " Accessory", statFactory.GenerateStatAmount(rarity));
                return item;
            case Item.ItemType.PANTS:
                item.Init(Item.ItemType.PANTS, rarity, GenerateItemSprite(ItemSprites.pantsSprites, rarity), rarity + " " + keyword + " Pants", statFactory.GenerateStatAmount(rarity));
                return item;
            case Item.ItemType.GLOVES:
                item.Init(Item.ItemType.GLOVES, rarity, GenerateItemSprite(ItemSprites.glovesSprites, rarity), rarity + " " + keyword + " Gloves", statFactory.GenerateStatAmount(rarity));
                return item;
            default:
                Debug.Log("Item Type not found");
                break;
        }
        throw new System.NotImplementedException();
    }
}
