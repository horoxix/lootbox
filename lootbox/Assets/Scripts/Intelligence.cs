using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intelligence : Stat {

    // Use this for initialization
    void Start()
    {
        statName = "Intelligence";
        rarity = Rarity.COMMON;
        affectedStat = AffectedStat.THEME;
    }
}
