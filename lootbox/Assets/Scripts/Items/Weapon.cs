using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {
    protected WeaponType weaponType;
    protected Luck luck;
    protected Strength strength;
    protected Dexterity dexterity;
    protected Intelligence intelligence;

    public enum WeaponType
    {
        SWORD,
        MACE,
        BOW,
        AXE,
        SPEAR
    }
}
