using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dexterity : Stat {

    // Use this for initialization
    void Start()
    {
        statName = "Dexterity";
        rarity = Rarity.UNCOMMON;
        affectedStat = AffectedStat.ACCUMULATION;
    }
}
