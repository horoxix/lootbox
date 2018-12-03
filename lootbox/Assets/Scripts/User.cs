using System;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {
    private float experience;
    private int level;
    private int inventorySlots;
    private int equipmentSlots;
    private int lootBoxes;
    private int currency;
    public List<Item> inventory;
    private Luck luck;
    private Dexterity dexterity;
    private Strength strength;
    private Intelligence intelligence;
    private float rareChange;
    private Helm equippedHelm;
    private Armor equippedArmor;
    private Weapon equippedRightHand;
    private Weapon equippedLeftHand;
    private Belt equippedBelt;
    private Boots equippedBoots;
    private Gloves equippedGloves;
    private Accessory equippedAccessory1;
    private Accessory equippedAccessory2;
    private Pants equippedPants;

    public static User user;

    void Awake()
    {
        if(user == null)
        {
            DontDestroyOnLoad(gameObject);
            user = this;
        }
        else if (user != this)
        {
            Destroy(gameObject);
        }
    }

    public float Experience
    {
        get
        {
            return experience;
        }

        set
        {
            experience = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public int InventorySlots
    {
        get
        {
            return inventorySlots;
        }

        set
        {
            inventorySlots = value;
        }
    }

    public int EquipmentSlots
    {
        get
        {
            return equipmentSlots;
        }

        set
        {
            equipmentSlots = value;
        }
    }

    public int LootBoxes
    {
        get
        {
            return lootBoxes;
        }

        set
        {
            lootBoxes = value;
        }
    }

    public int Currency
    {
        get
        {
            return currency;
        }

        set
        {
            currency = value;
        }
    }

    public Luck Luck
    {
        get
        {
            return luck;
        }

        set
        {
            luck = value;
        }
    }

    public Dexterity Dexterity
    {
        get
        {
            return dexterity;
        }

        set
        {
            dexterity = value;
        }
    }

    public Strength Strength
    {
        get
        {
            return strength;
        }

        set
        {
            strength = value;
        }
    }

    public Intelligence Intelligence
    {
        get
        {
            return intelligence;
        }

        set
        {
            intelligence = value;
        }
    }

    public float RareChange
    {
        get
        {
            return rareChange;
        }

        set
        {
            rareChange = value;
        }
    }

    public Helm EquippedHelm
    {
        get
        {
            return equippedHelm;
        }

        set
        {
            equippedHelm = value;
        }
    }

    public Armor EquippedArmor
    {
        get
        {
            return equippedArmor;
        }

        set
        {
            equippedArmor = value;
        }
    }

    public Weapon EquippedRightHand
    {
        get
        {
            return equippedRightHand;
        }

        set
        {
            equippedRightHand = value;
        }
    }

    public Weapon EquippedLeftHand
    {
        get
        {
            return equippedLeftHand;
        }

        set
        {
            equippedLeftHand = value;
        }
    }

    public Belt EquippedBelt
    {
        get
        {
            return equippedBelt;
        }

        set
        {
            equippedBelt = value;
        }
    }

    public Boots EquippedBoots
    {
        get
        {
            return equippedBoots;
        }

        set
        {
            equippedBoots = value;
        }
    }

    public Gloves EquippedGloves
    {
        get
        {
            return equippedGloves;
        }

        set
        {
            equippedGloves = value;
        }
    }

    public Accessory EquippedAccessory1
    {
        get
        {
            return equippedAccessory1;
        }

        set
        {
            equippedAccessory1 = value;
        }
    }

    public Accessory EquippedAccessory2
    {
        get
        {
            return equippedAccessory2;
        }

        set
        {
            equippedAccessory2 = value;
        }
    }

    public Pants EquippedPants
    {
        get
        {
            return equippedPants;
        }

        set
        {
            equippedPants = value;
        }
    }



    // Use this for initialization
    void Start () {

	}
}

[Serializable]
class PlayerData
{
    private float experience;
    private int level;
    private int inventorySlots;
    private int equipmentSlots;
    private int lootBoxes;
    private int currency;
    private List<Item> inventory;
    private Luck luck;
    private Dexterity dexterity;
    private Strength strength;
    private Intelligence intelligence;
    private float rareChange;
    private Helm equippedHelm;
    private Armor equippedArmor;
    private Weapon equippedRightHand;
    private Weapon equippedLeftHand;
    private Belt equippedBelt;
    private Boots equippedBoots;
    private Gloves equippedGloves;
    private Accessory equippedAccessory1;
    private Accessory equippedAccessory2;
    private Pants equippedPants;

    public float Experience
    {
        get
        {
            return experience;
        }

        set
        {
            experience = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public int InventorySlots
    {
        get
        {
            return inventorySlots;
        }

        set
        {
            inventorySlots = value;
        }
    }

    public int EquipmentSlots
    {
        get
        {
            return equipmentSlots;
        }

        set
        {
            equipmentSlots = value;
        }
    }

    public int LootBoxes
    {
        get
        {
            return lootBoxes;
        }

        set
        {
            lootBoxes = value;
        }
    }

    public int Currency
    {
        get
        {
            return currency;
        }

        set
        {
            currency = value;
        }
    }

    public Luck Luck
    {
        get
        {
            return luck;
        }

        set
        {
            luck = value;
        }
    }

    public Dexterity Dexterity
    {
        get
        {
            return dexterity;
        }

        set
        {
            dexterity = value;
        }
    }

    public Strength Strength
    {
        get
        {
            return strength;
        }

        set
        {
            strength = value;
        }
    }

    public Intelligence Intelligence
    {
        get
        {
            return intelligence;
        }

        set
        {
            intelligence = value;
        }
    }

    public float RareChange
    {
        get
        {
            return rareChange;
        }

        set
        {
            rareChange = value;
        }
    }

    public List<Item> Inventory
    {
        get
        {
            return inventory;
        }

        set
        {
            inventory = value;
        }
    }

    public Helm EquippedHelm
    {
        get
        {
            return equippedHelm;
        }

        set
        {
            equippedHelm = value;
        }
    }

    public Armor EquippedArmor
    {
        get
        {
            return equippedArmor;
        }

        set
        {
            equippedArmor = value;
        }
    }

    public Weapon EquippedRightHand
    {
        get
        {
            return equippedRightHand;
        }

        set
        {
            equippedRightHand = value;
        }
    }

    public Weapon EquippedLeftHand
    {
        get
        {
            return equippedLeftHand;
        }

        set
        {
            equippedLeftHand = value;
        }
    }

    public Belt EquippedBelt
    {
        get
        {
            return equippedBelt;
        }

        set
        {
            equippedBelt = value;
        }
    }

    public Boots EquippedBoots
    {
        get
        {
            return equippedBoots;
        }

        set
        {
            equippedBoots = value;
        }
    }

    public Gloves EquippedGloves
    {
        get
        {
            return equippedGloves;
        }

        set
        {
            equippedGloves = value;
        }
    }

    public Accessory EquippedAccessory1
    {
        get
        {
            return equippedAccessory1;
        }

        set
        {
            equippedAccessory1 = value;
        }
    }

    public Accessory EquippedAccessory2
    {
        get
        {
            return equippedAccessory2;
        }

        set
        {
            equippedAccessory2 = value;
        }
    }

    public Pants EquippedPants
    {
        get
        {
            return equippedPants;
        }

        set
        {
            equippedPants = value;
        }
    }
}
