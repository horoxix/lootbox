using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory : Item {

    // Use this for initialization
    protected override void Start()
    {
        itemType = ItemType.ACCESSORY;
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
