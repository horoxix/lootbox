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
                if(User.user.equippedLeftHand != null)
                {
                    if(User.user.equippedRightHand != null)
                    {
                        UnequipItem(User.user.equippedLeftHand);
                        User.user.equippedLeftHand = selectedItem;
                    }
                    else
                    {
                        User.user.equippedRightHand = selectedItem;
                    }
                }
                else
                {
                    User.user.equippedLeftHand = selectedItem;
                }
                break;
            case "armor":
                CheckForEquipped(User.user.equippedArmor);
                User.user.equippedArmor = selectedItem;
                break;
            case "boots":
                if (User.user.equippedBoots != null)
                {
                    UnequipItem(User.user.equippedBoots);
                }
                User.user.equippedBoots = selectedItem;
                break;
            case "helm":
                if (User.user.equippedHelm != null)
                {
                    UnequipItem(User.user.equippedHelm);
                }
                User.user.equippedHelm = selectedItem;
                break;
            case "belt":
                if (User.user.equippedBelt != null)
                {
                    UnequipItem(User.user.equippedBelt);
                }
                User.user.equippedBelt = selectedItem;
                break;
            case "accessory":
                if (User.user.equippedAccessory1 != null)
                {
                    if (User.user.equippedAccessory2 != null)
                    {
                        UnequipItem(User.user.equippedAccessory1);
                        User.user.equippedAccessory1 = selectedItem;
                    }
                    else
                    {
                        User.user.equippedAccessory2 = selectedItem;
                    }
                }
                else
                {
                    User.user.equippedAccessory1 = selectedItem;
                }
                break;
            case "pants":
                if (User.user.equippedPants != null)
                {
                    UnequipItem(User.user.equippedPants);
                }
                User.user.equippedPants = selectedItem;
                break;
            case "gloves":
                if (User.user.equippedGloves != null)
                {
                    UnequipItem(User.user.equippedGloves);
                }
                User.user.equippedGloves = selectedItem;
                break;
            default:
                Debug.Log("Item Type not found");
                break;
        }
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

    private void CheckForEquipped(Item userItem)
    {
        if (userItem != null)
        {
            UnequipItem(userItem);
        }
    }

    private void UnequipItem(Item item)
    {
        Debug.Log("Unequipped : " + item.itemName);
        foreach (Stat modifier in item.modifierList)
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
    }
}

