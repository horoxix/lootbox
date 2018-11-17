using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {

    // Use this for initialization
    protected override void Start()
    {
        itemType = ItemType.WEAPON;
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
