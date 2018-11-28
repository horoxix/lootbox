using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponFactory
{ 
    public abstract Weapon Create(Weapon.WeaponType weaponType, GameObject gameObject);

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

    protected Sprite GenerateWeaponSprite(Dictionary<string, Sprite> dict, Item.Rarity rarity) 
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
        }
        throw new NotImplementedException();
    }
}
