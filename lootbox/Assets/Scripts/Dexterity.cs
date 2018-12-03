using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dexterity : Stat {

    public Dexterity(string statName, StatType statType, Rarity rarity, AffectedStat affectedStat, int statValue)
    {
        this.StatName = statName;
        this.statType = statType;
        this.StatValue = statValue;
        this.affectedStat = affectedStat;
        this.rarity = rarity;
    }
}
