using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour {
    [SerializeField] GameObject Loot;
    [SerializeField] User user;
    private RandomManager randomManager;
    private List<Item> items;

    private void Start()
    {
        randomManager = FindObjectOfType<RandomManager>();
        items = Item.itemTypeList;
    }

    // On click to OpenBox, looks at how many items are in the box and adds an Item.
    // TODO : In UI, add item to specific gameObjects.
    public void OpenBox(LootBox lootBox)
    {
        for(int i=0; i < lootBox.ItemCount; i++)
        {
            Type typeofItem = GenerateLoot(items);
            user.myInventory.items.Add(Loot.AddComponent(typeofItem) as Item);
        }
        StartCoroutine(DisplayNames());
    }

    public IEnumerator DisplayNames()
    {
        yield return new WaitForSeconds(1.0f);
        for (int j = 0; j < user.myInventory.items.Count; j++)
        {
            Debug.Log(user.myInventory.items[j].ItemName);
        }
    }

    public Type GenerateLoot(List<Item> list)
    {
        Type type = randomManager.RandomList(list);
        return type;
    }
        
    }
