using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteItemFactory : ItemFactory {

    public override Item GetItem(string item)
    {
        switch (item)
        {
            case "Weapon":
                return new Weapon();
            case "Armor":
                return new Armor();
            case "Boots":
                return new Boots();
            case "Helm":
                return new Helm();
            case "Belt":
                return new Belt();
            case "Accessory":
                return new Accessory();
            case "Pants":
                return new Pants();
            case "Gloves":
                return new Gloves();
        }
        throw new System.NotImplementedException();
    }
}
