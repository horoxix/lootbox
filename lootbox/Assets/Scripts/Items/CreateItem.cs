using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System;

public class CreateItem
{
    // Generates an Item
    public static Item Create()
    {
        GenerateSprite generateSprite = new GenerateSprite();
        RandomManager randomManager = new RandomManager();
        StatFactory statFactory = new ConcreteStatFactory();
        Item asset = ScriptableObject.CreateInstance<Item>();
        randomManager.SetAnimationCurve();
        asset.itemType = (Item.ItemType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Item.ItemType)).Length);
        asset.itemTypeName = asset.itemType.ToString().ToLower();
        asset.rarity = (Item.Rarity)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.cumulativeProbability));
        asset.keyword = (Item.Keywords)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.cumulativeProbability));
        asset.statCount = statFactory.GenerateStatAmount(asset.rarity);
        asset.modifierList = new List<Stat>();
        for (int i = 0; i < asset.statCount; i++)
        {
            asset.modifierList.Add(statFactory.GetStat(statFactory.GenerateStatType(), asset));
        }
        asset.itemName = asset.keyword.ToString().ToLower() + " " + asset.rarity.ToString().ToLower() + " " + asset.itemTypeName;
        asset.itemSpriteList = generateSprite.GenerateSpriteList(asset.itemType);
        asset.itemSprite = GenerateSpriteType(asset.itemSpriteList, asset.rarity);
        asset.ItemLevel = GenerateItemLevel(asset.rarity);
        asset.itemBackgroundSprite = GenerateSpriteType(BackgroundSprites.backgroundSprites, asset.rarity);
        return asset;
    }

    // For use if we want to save the asset as a data file.
    public void SaveAsset(Item item)
    {
        //AssetDatabase.CreateAsset(asset, "Assets/Data/" + asset.itemName + "-" + Guid.NewGuid() + ".asset");
        //AssetDatabase.SaveAssets();
    }

    // Generates the sprite based on rarity of the item.
    public static Sprite GenerateSpriteType(Dictionary<string, Sprite> dict, Item.Rarity rarity)
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

    // Generates the item level based on rarity
    // TODO : * by player level.
    public static int GenerateItemLevel(Item.Rarity rarity) 
    {
        switch (rarity)
        {
            case Item.Rarity.COMMON:
                return UnityEngine.Random.Range(1, 10);
            case Item.Rarity.UNCOMMON:
                return UnityEngine.Random.Range(11, 21);
            case Item.Rarity.RARE:
                return UnityEngine.Random.Range(24, 50);
            case Item.Rarity.EPIC:
                return UnityEngine.Random.Range(75, 100);
            case Item.Rarity.LEGENDARY:
                return UnityEngine.Random.Range(100, 300);
        }
        throw new NotImplementedException();
    }
}
