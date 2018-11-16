using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour {
    protected string statName;
    protected AffectedStat affectedStat;
    protected Rarity rarity;

    // How often stat boost will appear as an affix.
    protected enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        EPIC,
        LEGENDARY
    }

    // The sub-stat modified by the parent stat.
    protected enum AffectedStat
    {
        RARITY,
        LOOT_AMOUNT,
        ACCUMULATION,
        DISENCHANT,
        THEME
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
