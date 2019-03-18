using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

public class CreateItemObject
{
    private static Stat stat;
    // Generates an Item
    // Pass in item taken from Open();
    public static ItemScriptableObject Generate(ItemScriptableObject iso)
    {
        GenerateSprite generateSprite = new GenerateSprite();
        RandomManager randomManager = new RandomManager();
        StatFactory statFactory = new ConcreteStatFactory();
        ItemScriptableObject itemScriptableObject = ScriptableObject.CreateInstance<ItemScriptableObject>();
        randomManager.SetAnimationCurve();
        itemScriptableObject.itemSprite = iso.itemSprite;
        itemScriptableObject.itemName = iso.itemName;
        itemScriptableObject.itemType = iso.itemType;
        itemScriptableObject.itemTypeName = iso.itemType.ToString().ToLower();
        itemScriptableObject.rarity = (ItemObject.Rarity)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.cumulativeProbability));
        itemScriptableObject.keyword = (ItemObject.Keywords)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.cumulativeProbability));
        itemScriptableObject.statCount = statFactory.GenerateStatAmountForObject(itemScriptableObject.rarity);
        itemScriptableObject.modifierList = new List<Stat>();
        for (int i = 0; i < itemScriptableObject.statCount; i++)
        {
            Stat.StatType statType = statFactory.GenerateStatType();
            Stat stat = statFactory.GetStatObject(statType, itemScriptableObject);
            int statIndex = DetectStatInList(itemScriptableObject.modifierList, statType);
            if (statIndex != -1)
            {
                itemScriptableObject.modifierList[statIndex].StatValue += stat.StatValue;
                itemScriptableObject.statCount--;
            }
            else
            {
                itemScriptableObject.modifierList.Add(stat);
            }
        }
        itemScriptableObject.itemBackgroundSprite = GenerateSpriteType(BackgroundSprites.backgroundSprites, itemScriptableObject.rarity);
        return itemScriptableObject;
    }

    // Generates the sprite based on rarity of the item.
    public static Sprite GenerateSpriteType(Dictionary<string, Sprite> dict, ItemObject.Rarity rarity)
    {
        switch (rarity)
        {
            case ItemObject.Rarity.COMMON:
                return dict["Common"];
            case ItemObject.Rarity.UNCOMMON:
                return dict["Uncommon"];
            case ItemObject.Rarity.RARE:
                return dict["Rare"];
            case ItemObject.Rarity.EPIC:
                return dict["Epic"];
            case ItemObject.Rarity.LEGENDARY:
                return dict["Legendary"];
            default:
                Debug.Log(dict + " " + rarity);
                break;
        }
        throw new NotImplementedException();
    }

    // Generates the item level based on rarity
    // TODO : * by player level.
    public static int GenerateItemLevel(ItemObject.Rarity rarity) 
    {
        switch (rarity)
        {
            case ItemObject.Rarity.COMMON:
                return UnityEngine.Random.Range(1, 10);
            case ItemObject.Rarity.UNCOMMON:
                return UnityEngine.Random.Range(11, 21);
            case ItemObject.Rarity.RARE:
                return UnityEngine.Random.Range(24, 50);
            case ItemObject.Rarity.EPIC:
                return UnityEngine.Random.Range(75, 100);
            case ItemObject.Rarity.LEGENDARY:
                return UnityEngine.Random.Range(100, 300);
        }
        throw new NotImplementedException();
    }

    // Takes gameobject, adds iso type component to it, sets component properties to be the properties of the iso.
    public static ItemObject GenerateItemObject(ItemScriptableObject iso)
    {
        return new ItemObject(iso.rarity, iso.keyword, iso.itemType, iso.itemName, iso.itemTypeName, iso.itemSprite, iso.itemBackgroundSprite, iso.modifierList, iso.value, iso.ItemLevel, iso.statCount);
    }

    public static int DetectStatInList(List<Stat> statList, Stat.StatType statType)
    {
        foreach (Stat stat in statList)
        {
            if (stat.statType == statType)
            {
                return statList.IndexOf(stat);
            }
        }
        return -1;
    }
}
