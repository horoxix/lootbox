using UnityEngine;

public class LootBox {
    private float dropRate;
    private int cost;
    public int lootBoxLevel;
    private int experience;
    public int itemCount;
    public LootType lootType;
    public LootBoxType lootBoxType;
    public Sprite lootBoxImage;
    public int lootBoxHealth;

    public LootBox(int cost, int level, int experience, int itemCount, LootType lootType, LootBoxType lootBoxType, Sprite lootBoxImage, int health)
    {
        this.cost = cost;
        this.lootBoxLevel = level;
        this.experience = experience;
        this.itemCount = itemCount;
        this.lootType = lootType;
        this.lootBoxType = lootBoxType;
        this.lootBoxImage = lootBoxImage;
        this.lootBoxHealth = health;
    }
    // How many items the lootBox holds.
    public int ItemCount
    {
        get
        {
            return itemCount;
        }

        set
        {
            itemCount = value;
        }
    }

    // How much experience you get for opening the loot box.
    public int Experience
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

    // TBT drop rate.
    public float DropRate
    {
        get
        {
            return dropRate;
        }

        set
        {
            dropRate = value;
        }
    }

    // How much the lootbox costs.
    public int Cost
    {
        get
        {
            return cost;
        }

        set
        {
            cost = value;
        }
    }

    // Paid or Free loot.
    public enum LootType
    {
        FREE,
        PAID
    }

    public enum LootBoxType
    {
        HEAVY,
        MEDIUM,
        LIGHT
    }
}
