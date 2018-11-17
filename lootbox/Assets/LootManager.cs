using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour {
    public List<GameObject> lootSlots;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform)
        {
            lootSlots.Add(child.gameObject);
        }
	}
	
}
