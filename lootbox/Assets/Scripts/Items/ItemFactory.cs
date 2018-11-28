using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemFactory {

    public abstract Item GetItem(Item.ItemType itemType, GameObject gameObject);

    RandomManager randomManager = new RandomManager();

    public Item.Rarity GenerateRarity()
    {
        randomManager.SetAnimationCurve();
        return (Item.Rarity)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.CumulativeProbability));
    }

    protected Item.Keywords GenerateKeyword()
    {
        randomManager.SetAnimationCurve();
        return (Item.Keywords)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.CumulativeProbability));
    }

    protected Sprite GenerateItemSprite(Dictionary<string, Sprite> dict, Item.Rarity rarity)
    {
        switch (rarity)
        {
            case Item.Rarity.COMMON:
                return dict["Common"];
            case Item.Rarity.UNCOMMON:
                return dict["Uncommon"];
            case Item.Rarity.RARE:
                return dict["Rare"];
            case Item.Rarity.EPIC:
                return dict["Epic"];
            case Item.Rarity.LEGENDARY:
                return dict["Legendary"];
            default:
                Debug.Log(dict + " " + rarity);
                break;
        }
        throw new NotImplementedException();
    }


    public Type GenerateType(Item.ItemType itemType)
    {
        switch (itemType)
        {
            case Item.ItemType.BELT:
                return typeof(Belt);
            case Item.ItemType.ACCESSORY:
                return typeof(Accessory);
            case Item.ItemType.HELM:
                return typeof(Helm);
            case Item.ItemType.ARMOR:
                return typeof(Armor);
            case Item.ItemType.BOOTS:
                return typeof(Boots);
            case Item.ItemType.PANTS:
                return typeof(Pants);
            case Item.ItemType.GLOVES:
                return typeof(Gloves);
        }
        throw new NotImplementedException();
    }
}
