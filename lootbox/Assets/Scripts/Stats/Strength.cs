using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strength : Stat {
    public Strength(string statName, StatType statType, Rarity rarity, AffectedStat affectedStat, int statValue)
    {
        this.StatName = statName;
        this.statType = statType;
        this.StatValue = statValue;
        this.affectedStat = affectedStat;
        this.rarity = rarity;
    }
}
