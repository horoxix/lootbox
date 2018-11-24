using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour {
    protected string statName;
    protected StatType statType;
    protected AffectedStat affectedStat;
    protected Rarity rarity;
    protected int statValue;

    public enum StatType
    {
        LUCK,
        STRENGTH,
        DEXTERITY,
        INTELLIGENCE
    }

    // How often stat boost will appear as an affix.
    public enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        EPIC,
        LEGENDARY
    }

    // The sub-stat modified by the parent stat.
    public enum AffectedStat
    {
        RARITY,
        LOOT_AMOUNT,
        ACCUMULATION,
        DISENCHANT,
        THEME
    }

    public void Instantiate(StatType statType, Rarity rarity, AffectedStat affectedStat, int statValue)
    {
        this.statType = statType;
        this.statValue = statValue;
        this.affectedStat = affectedStat;
        this.rarity = rarity;
    }
}
