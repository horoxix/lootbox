using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    protected string itemName;
    protected Rarity rarity;
    protected Keywords keyword;
    protected ItemType itemType;
    protected RandomManager randomManager;

    // Enum list of possible Item Types.
    protected enum ItemType
    {
        RIGHT_HAND,
        LEFT_HAND,
        ARMOR,
        PANTS,
        BOOTS,
        HELM,
        BELT,
        ACCESSORY
    }

    // Enum list of possible Rarity values.
    protected enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        EPIC,
        LEGENDARY,
        UNIQUE
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
	void Start () {
        randomManager = FindObjectOfType<RandomManager>();
        keyword = (Keywords)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.CumulativeProbability));
        itemType = (ItemType)Random.Range(0, System.Enum.GetValues(typeof(ItemType)).Length);
        rarity = (Rarity)Mathf.RoundToInt(randomManager.CurveWeightedRandom(randomManager.CumulativeProbability));
        itemName = keyword + " " + itemType;
        Debug.Log("Generated " + itemName + " " + rarity); 
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

}
