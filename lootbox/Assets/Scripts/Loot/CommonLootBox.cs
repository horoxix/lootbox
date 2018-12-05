using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonLootBox : LootBox {

	// Use this for initialization
	void Start () {
        lootType = LootType.FREE;
        itemCount = 4;
        cost = 100;
        dropRate = 1;
        Experience = Random.Range(5, 10);
	}
}
