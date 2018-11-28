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
}
