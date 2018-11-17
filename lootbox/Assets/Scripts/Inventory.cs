using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> items;

    private void Start()
    {
        items = new List<Item>();
    }
}
