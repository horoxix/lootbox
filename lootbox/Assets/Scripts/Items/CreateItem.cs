using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System;

public class CreateItem
{
    //[MenuItem("Assets/Create/Item")]
    public static Item Create()
    {
        GenerateSprite generateSprite = new GenerateSprite();
        Item asset = ScriptableObject.CreateInstance<Item>();
        asset.itemType = (Item.ItemType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Item.ItemType)).Length);
        asset.itemTypeName = asset.itemType.ToString().ToLower();
        RandomManager randomManager = new RandomManager();
        randomManager.SetAnimationCurve();
        asset.rarity = (Item.Rarity)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.cumulativeProbability));
        asset.keyword = (Item.Keywords)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.cumulativeProbability));
        StatFactory statFactory = new ConcreteStatFactory();
        asset.statCount = statFactory.GenerateStatAmount(asset.rarity);
        asset.modifierList = new List<Stat>();
        for (int i = 0; i < asset.statCount; i++)
        {
            asset.modifierList.Add(statFactory.GetStat(statFactory.GenerateStatType(), asset));
            Debug.Log(asset.modifierList[i].StatName + " " + asset.modifierList[i].StatValue);
        }
        asset.itemName = asset.keyword.ToString().ToLower() + " " + asset.rarity.ToString().ToLower() + " " + asset.itemTypeName;
        asset.itemSpriteList = generateSprite.GenerateSpriteList(asset.itemType);
        asset.itemSprite = GenerateSpriteType(asset.itemSpriteList, asset.rarity);
        asset.ItemLevel = GenerateItemLevel(asset.rarity);
        //AssetDatabase.CreateAsset(asset, "Assets/Data/" + asset.itemName + "-" + Guid.NewGuid() + ".asset");
        //AssetDatabase.SaveAssets();
        return asset;
    }

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
