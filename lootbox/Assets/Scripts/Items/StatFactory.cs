using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatFactory {

    public abstract Stat GetStat(Stat.StatType statType, Item item);

    RandomManager randomManager = new RandomManager();

    public int GenerateStatAmount(Item.Rarity rarity)
    {
        switch (rarity)
        {
            case Item.Rarity.COMMON:
                return 1;
            case Item.Rarity.UNCOMMON:
                return 2;
            case Item.Rarity.RARE:
                return 3;
            case Item.Rarity.EPIC:
                return 4;
            case Item.Rarity.LEGENDARY:
                return 5;
        }
        throw new NotImplementedException();
    }

    public Stat.StatType GenerateStatType()
    {
        randomManager.SetAnimationCurve();
        return (Stat.StatType)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.CumulativeProbability));
    }

    protected void GenerateAmountOfStats(int numberOfStats)
    {
        for (int i = 0; i < numberOfStats; i++)
        {
            GenerateStatType();
        }
    }

    protected int GenerateStatValue(Item.Rarity rarity)
    {
        switch (rarity)
        {
            case Item.Rarity.COMMON:
                return UnityEngine.Random.Range(1,10);
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

    protected Item.Rarity GetItemRarity(Item item)
    {
        return item.rarity;
    }
}
