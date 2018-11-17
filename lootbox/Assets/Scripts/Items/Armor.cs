using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item {

    // Use this for initialization
    protected override void Start()
    {
        itemType = ItemType.ARMOR;
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
