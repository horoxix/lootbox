using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponFactory
{ 
    public abstract Weapon Create(Weapon.WeaponType weaponType, GameObject gameObject);


    public Item.Rarity GenerateRarity()
    {
        RandomManager.randomManager.SetAnimationCurve();
        return (Item.Rarity)Mathf.RoundToInt(RandomManager.randomManager.CurveWeightedRandom(RandomManager.randomManager.cumulativeProbability));
    }

    protected Item.Keywords GenerateKeyword()
    {
        RandomManager.randomManager.SetAnimationCurve();
        return (Item.Keywords)Mathf.RoundToInt(RandomManager.randomManager.CurveWeightedRandom(RandomManager.randomManager.cumulativeProbability));
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
