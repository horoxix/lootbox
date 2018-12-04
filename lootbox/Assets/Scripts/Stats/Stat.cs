using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat {
    private string statName;
    public StatType statType;
    protected AffectedStat affectedStat;
    protected Rarity rarity;
    private int statValue;

    public int StatValue
    {
        get
        {
            return statValue;
        }

        set
        {
            statValue = value;
        }
    }

    public string StatName
    {
        get
        {
            return statName;
        }

        set
        {
            statName = value;
        }
    }

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

    public void Instantiate(string statName, StatType statType, Rarity rarity, AffectedStat affectedStat, int statValue)
    {
        this.statName = statName;
        this.statType = statType;
        this.StatValue = statValue;
        this.affectedStat = affectedStat;
        this.rarity = rarity;
    }
}
