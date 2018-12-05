using System;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {
    private string playerName;
    private float experience;
    private float experienceToNext;
    private int level;
    private int inventorySlots;
    private int equipmentSlots;
    private int lootBoxes;
    private int currency;
    public List<Item> inventory;
    public Luck luck;
    public Dexterity dexterity;
    public Strength strength;
    public Intelligence intelligence;
    private float rareChange;
    public Item equippedHelm;
    public Item equippedArmor;
    public Item equippedRightHand;
    public Item equippedLeftHand;
    public Item equippedBelt;
    public Item equippedBoots;
    public Item equippedGloves;
    public Item equippedAccessory1;
    public Item equippedAccessory2;
    public Item equippedPants;

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
        luck = new Luck("Luck", Stat.StatType.LUCK, Stat.Rarity.RARE, Stat.AffectedStat.RARITY, 0);
        dexterity = new Dexterity("Dexterity", Stat.StatType.DEXTERITY, Stat.Rarity.UNCOMMON, Stat.AffectedStat.ACCUMULATION, 0);
        intelligence = new Intelligence("Intelligence", Stat.StatType.INTELLIGENCE, Stat.Rarity.COMMON, Stat.AffectedStat.THEME, 0);
        strength = new Strength("Strength", Stat.StatType.STRENGTH, Stat.Rarity.COMMON, Stat.AffectedStat.LOOT_AMOUNT, 0);
        playerName = "Holden";
        level = 1;
        lootBoxes = 1;
        experienceToNext = 100;
    }

    void Start()
    {

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


    public string PlayerName
    {
        get
        {
            return playerName;
        }

        set
        {
            playerName = value;
        }
    }

    public float ExperienceToNext
    {
        get
        {
            return experienceToNext;
        }

        set
        {
            experienceToNext = value;
        }
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
    private Item equippedHelm;
    private Item equippedArmor;
    private Item equippedRightHand;
    private Item equippedLeftHand;
    private Item equippedBelt;
    private Item equippedBoots;
    private Item equippedGloves;
    private Item equippedAccessory1;
    private Item equippedAccessory2;
    private Item equippedPants;

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

    public Item EquippedHelm
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

    public Item EquippedArmor
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

    public Item EquippedRightHand
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

    public Item EquippedLeftHand
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

    public Item EquippedBelt
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

    public Item EquippedBoots
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

    public Item EquippedGloves
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

    public Item EquippedAccessory1
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

    public Item EquippedAccessory2
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

    public Item EquippedPants
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
