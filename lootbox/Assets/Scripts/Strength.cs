using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strength : Stat {

    // Use this for initialization
    void Start()
    {
        statName = "Strength";
        rarity = Rarity.UNCOMMON;
        affectedStat = AffectedStat.LOOT_AMOUNT;
    }
}
