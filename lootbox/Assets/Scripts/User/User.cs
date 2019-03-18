using System;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {
    private string playerName;
    private float experience;
    private float experienceToNext;
    private int level;
    private int inventorySlots;
    private int weaponSlots;
    private int equipmentSlots;
    private int lootBoxes;
    private int maxLootBoxes;
    private int lastLootBoxAccumulatedTime;
    private int currency;
    private float rareChange;
    public List<ItemObject> inventory;
    public List<ItemObject> weapons;
    public List<ItemObject> consumables;
    public Luck luck;
    public Dexterity dexterity;
    public Strength strength;
    public Intelligence intelligence;
    public ItemObject equippedHelm;
    public ItemObject equippedArmor;
    public ItemObject equippedRightHand;
    public ItemObject equippedLeftHand;
    public ItemObject equippedBelt;
    public ItemObject equippedBoots;
    public ItemObject equippedGloves;
    public ItemObject equippedAccessory1;
    public ItemObject equippedAccessory2;
    public ItemObject equippedPants;

    public static User user;

    void Awake()
    {
        if(user == null)
        {
            user = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (user != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        luck = new Luck("Luck", Stat.StatType.LUCK, Stat.Rarity.RARE, Stat.AffectedStat.RARITY, 0);
        dexterity = new Dexterity("Dexterity", Stat.StatType.DEXTERITY, Stat.Rarity.UNCOMMON, Stat.AffectedStat.ACCUMULATION, 0);
        intelligence = new Intelligence("Intelligence", Stat.StatType.INTELLIGENCE, Stat.Rarity.COMMON, Stat.AffectedStat.THEME, 0);
        strength = new Strength("Strength", Stat.StatType.STRENGTH, Stat.Rarity.COMMON, Stat.AffectedStat.LOOT_AMOUNT, 0);
        playerName = "";
        level = 1;
        lootBoxes = 1;
        maxLootBoxes = 5;
        inventorySlots = 12;
        weaponSlots = 2;
        experienceToNext = 100;
        lastLootBoxAccumulatedTime = 100;
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

    public int MaxLootBoxes
    {
        get
        {
            return maxLootBoxes;
        }

        set
        {
            maxLootBoxes = value;
        }
    }

    public int LastTimeOpenedLootBox
    {
        get
        {
            return lastLootBoxAccumulatedTime;
        }

        set
        {
            lastLootBoxAccumulatedTime = value;
        }
    }

    public int WeaponSlots
    {
        get
        {
            return weaponSlots;
        }

        set
        {
            weaponSlots = value;
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
    private List<ItemObject> inventory;
    private int luck;
    private int dexterity;
    private int strength;
    private int intelligence;
    private float rareChange;
    private string equippedHelm;
    private string equippedArmor;
    private string equippedRightHand;
    private string equippedLeftHand;
    private string equippedBelt;
    private string equippedBoots;
    private string equippedGloves;
    private string equippedAccessory1;
    private string equippedAccessory2;
    private string equippedPants;

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

    public int Luck
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

    public int Dexterity
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

    public int Strength
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

    public int Intelligence
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

    public List<ItemObject> Inventory
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

    public string EquippedHelm
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

    public string EquippedArmor
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

    public string EquippedRightHand
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

    public string EquippedLeftHand
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

    public string EquippedBelt
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

    public string EquippedBoots
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

    public string EquippedGloves
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

    public string EquippedAccessory1
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

    public string EquippedAccessory2
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

    public string EquippedPants
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
