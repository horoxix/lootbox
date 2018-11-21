using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {
    protected WeaponType weaponType;
    protected Luck luck;
    protected Strength strength;
    protected Dexterity dexterity;
    protected Intelligence intelligence;

    public static List<Weapon> weaponTypeList = new List<Weapon>()
{
    new Sword(),
    new Mace(),
    new Bow(),
    new Spear(),
    new Axe(),
};

    protected enum WeaponType
    {
        SWORD,
        MACE,
        BOW,
        AXE,
        SPEAR
    }

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
