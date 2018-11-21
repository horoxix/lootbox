using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteWeaponFactory : ItemFactory {

    public override Item GetItem(string item)
    {
        switch (item)
        {
            case "Sword":
                return new Sword();
            case "Mace":
                return new Mace();
            case "Bow":
                return new Bow();
            case "Axe":
                return new Axe();
            case "Spear":
                return new Spear();
        }
        throw new System.NotImplementedException();
    }
}
