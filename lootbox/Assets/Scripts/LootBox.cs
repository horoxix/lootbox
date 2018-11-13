using UnityEngine;

public class LootBox : MonoBehaviour {
    protected float dropRate;
    protected int cost;
    protected int itemCount;
    protected LootType lootType;

    protected enum LootType
    {
        FREE,
        PAID
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
