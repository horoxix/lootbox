using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour {
    public Item selectedItem;
    public Item previousItem;

    public void EquipItem()
    {
        if (previousItem != null)
        {
            UnEquip();
        }
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
        if (selectedItem.equipped == false)
        {
            foreach (Stat modifier in selectedItem.modifierList)
            {
                switch (modifier.statType)
                {
                    case Stat.StatType.LUCK:
                        User.user.luck.StatValue += modifier.StatValue;
                        break;
                    case Stat.StatType.DEXTERITY:
                        User.user.dexterity.StatValue += modifier.StatValue;
                        break;
                    case Stat.StatType.INTELLIGENCE:
                        User.user.intelligence.StatValue += modifier.StatValue;
                        break;
                    case Stat.StatType.STRENGTH:
                        User.user.strength.StatValue += modifier.StatValue;
                        break;
                }
            }
        }
        selectedItem.equipped = true;
        previousItem = selectedItem;
    }

    public void UnEquip()
    {
        switch (selectedItem.itemTypeName)
        {
            case "weapon":
                User.user.equippedLeftHand = null;
                break;
            case "armor":
                User.user.equippedArmor = null;
                break;
            case "boots":
                User.user.equippedBoots = null;
                break;
            case "helm":
                User.user.equippedHelm = null;
                break;
            case "belt":
                User.user.equippedBelt = null;
                break;
            case "accessory":
                User.user.equippedAccessory1 = null;
                break;
            case "pants":
                User.user.equippedPants = null;
                break;
            case "gloves":
                User.user.equippedGloves = null;
                break;
            default:
                Debug.Log("Item Type not found");
                break;
        }
        if(previousItem.equipped == true)
        {
            foreach (Stat modifier in previousItem.modifierList)
            {
                switch (modifier.statType)
                {
                    case Stat.StatType.LUCK:
                        User.user.luck.StatValue -= modifier.StatValue;
                        break;
                    case Stat.StatType.DEXTERITY:
                        User.user.dexterity.StatValue -= modifier.StatValue;
                        break;
                    case Stat.StatType.INTELLIGENCE:
                        User.user.intelligence.StatValue -= modifier.StatValue;
                        break;
                    case Stat.StatType.STRENGTH:
                        User.user.strength.StatValue -= modifier.StatValue;
                        break;
                }
            }
        } else { return; }
        previousItem.equipped = false;
    }
}

