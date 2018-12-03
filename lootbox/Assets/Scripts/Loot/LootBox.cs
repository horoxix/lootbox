using UnityEngine;

public class LootBox : MonoBehaviour {
    protected float dropRate;
    protected int cost;
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

    protected enum LootType
    {
        FREE,
        PAID
    }
}
