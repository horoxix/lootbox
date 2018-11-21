using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {
    private string itemName;
    protected string generatedName;
    protected Rarity rarity;
    protected Keywords keyword;
    protected ItemType itemType;
    protected RandomManager randomManager;
    [SerializeField]
    protected Sprite itemSprite;
    protected int value;

    public static List<Item> itemTypeList = new List<Item>()
{
    new Weapon(),
    new Helm(),
    new Pants(),
    new Gloves(),
    new Boots(),
    new Belt(),
    new Accessory(),
    new Armor()
};

    public string ItemName
    {
        get
        {
            return itemName;
        }

        set
        {
            itemName = value;
        }
    }

    // Enum list of possible Item Types.
    public enum ItemType
    {
        WEAPON,
        ARMOR,
        PANTS,
        BOOTS,
        HELM,
        BELT,
        ACCESSORY,
        GLOVES
    }

    // Enum list of possible Rarity values.
    protected enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        EPIC,
        LEGENDARY,
    }

    // Enum list of possible Keywords.
    protected enum Keywords
    {
        NORMAL,
        DAMAGED,
        RUSTY,
        MAGIC,
        PERFECT,
        EXQUISITE
    }

    // Randomly sets the values of the item based on the enums.
	protected virtual void Start () {
        value = UnityEngine.Random.Range(1, 100);
        GenerateKeyword();
        itemName = keyword + " " + generatedName;
        Debug.Log(itemName);
    }

    protected void GenerateKeyword()
    {
        keyword = (Keywords)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.CumulativeProbability));
    }

    protected void GenerateRarity()
    {
        rarity = (Rarity)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.CumulativeProbability));
    }

    // Debug purposes. Logs all time/key pairs for animationCurve.
    private void DebugLogKeys()
    {
        for (int i = 0; i < randomManager.CumulativeProbability.keys.Length; i++)
        {
            Debug.Log("Time: " + randomManager.CumulativeProbability.keys[i].time);
            Debug.Log("Key: " + randomManager.CumulativeProbability.keys[i].value);
        }
    }

    protected void CheckRarity(Dictionary<string, Sprite> dict)
    {
        switch (rarity)
        {
            case Rarity.COMMON:
                itemSprite = dict["Common"];
                break;
            case Rarity.UNCOMMON:
                itemSprite = dict["Uncommon"];
                break;
            case Rarity.RARE:
                itemSprite = dict["Rare"];
                break;
            case Rarity.EPIC:
                itemSprite = dict["Epic"];
                break;
            case Rarity.LEGENDARY:
                itemSprite = dict["Legendary"];
                break;
        }
    }

}
