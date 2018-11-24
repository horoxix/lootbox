using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour{
    public string itemName;
    public Rarity rarity;
    public Keywords keyword;
    public ItemType itemType;
    protected RandomManager randomManager;
    [SerializeField]
    public Sprite itemSprite;
    public int value;
    public int statCount;

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
    public enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        EPIC,
        LEGENDARY,
    }

    // Enum list of possible Keywords.
    public enum Keywords
    {
        NORMAL,
        DAMAGED,
        RUSTY,
        MAGIC,
        PERFECT,
        EXQUISITE
    }

    protected void GenerateItemType()
    {
        itemType = (ItemType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(ItemType)).Length);
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

    public void Instantiate(ItemType itemType, Rarity rarity, Sprite itemSprite, string itemName, int statCount)
    {
        this.itemType = itemType;
        this.itemSprite = itemSprite;
        this.rarity = rarity;
        this.itemName = itemName;
        this.value = 100;
        this.statCount = statCount;
    }
}
