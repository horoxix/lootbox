using UnityEngine;

public class LootBox : MonoBehaviour {
    protected float dropRate;
    protected int cost;
    private int experience;
    protected int itemCount;
    protected LootType lootType;

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

    protected enum LootType
    {
        FREE,
        PAID
    }
}
