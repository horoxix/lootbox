using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour {
    public Item selectedItem;

    public void EquipItem()
    {
        Debug.Log("Equipped : " + selectedItem.itemName);
        switch(selectedItem.itemTypeName) {
            case "weapon":
                User.user.equippedLeftHand = selectedItem;
                break;
            case "armor":
                User.user.equippedArmor = selectedItem;
                break;
            case "boots":
                User.user.equippedBoots = selectedItem;
                break;
            case "helm":
                User.user.equippedHelm = selectedItem;
                break;
            case "belt":
                User.user.equippedBelt = selectedItem;
                break;
            case "accessory":
                User.user.equippedAccessory1 = selectedItem;
                break;
            case "pants":
                User.user.equippedPants = selectedItem;
                break;
            case "gloves":
                User.user.equippedGloves = selectedItem;
                break;
            default:
                Debug.Log("Item Type not found");
                break;
        }
    }
}

