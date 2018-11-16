using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luck : Stat {

    // Use this for initialization
    void Start()
    {
        statName = "Luck";
        rarity = Rarity.RARE;
        affectedStat = AffectedStat.RARITY;
    }
}
