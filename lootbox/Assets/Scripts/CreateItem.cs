using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System;

public class CreateItem
{
    [MenuItem("Assets/Create/Item")]
    public static Item Create()
    {
        GenerateSprite generateSprite = new GenerateSprite();
        Item asset = ScriptableObject.CreateInstance<Item>();
        asset.itemName = asset.keyword.ToString().ToLower() + " " + asset.rarity.ToString().ToLower() + " " + asset.itemTypeName;
        asset.itemSpriteList = generateSprite.GenerateSpriteList(asset.itemType);
        asset.itemSprite = GenerateSpriteType(asset.itemSpriteList, asset.rarity);
        AssetDatabase.CreateAsset(asset, "Assets/Data/" + asset.itemName + "-" + Guid.NewGuid() + ".asset");
        AssetDatabase.SaveAssets();
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
}
