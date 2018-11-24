using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strength : Stat {
    public Strength(StatType statType, Rarity rarity, AffectedStat affectedStat, int statValue)
    {
        this.statType = statType;
        this.statValue = statValue;
        this.affectedStat = affectedStat;
        this.rarity = rarity;
    }
}
