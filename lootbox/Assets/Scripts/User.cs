using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User : MonoBehaviour {
    protected float experience;
    protected int level;
    protected int inventorySlots;
    protected int equipmentSlots;
    protected int lootBoxes;
    public int currency;
    public Inventory myInventory;
    protected Luck luck;
    protected Dexterity dexterity;
    protected Strength strength;
    protected Intelligence intelligence;
    protected float rareChange;

    // Use this for initialization
    void Start () {
        myInventory = gameObject.AddComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
