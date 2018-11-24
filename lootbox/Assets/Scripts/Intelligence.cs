using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intelligence : Stat {

    public Intelligence(StatType statType, Rarity rarity, AffectedStat affectedStat, int statValue)
    {
        this.statType = statType;
        this.statValue = statValue;
        this.affectedStat = affectedStat;
        this.rarity = rarity;
    }
}
