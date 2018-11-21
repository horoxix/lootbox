using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour {
    [SerializeField] GameObject Loot;
    [SerializeField] User user;
    [SerializeField] LootManager lootManager;
    private RandomManager randomManager;
    private List<Item> items;
    private ItemFactory itemFactory;
    private ItemFactory weaponFactory;

    private void Start()
    {
        itemFactory = new ConcreteItemFactory();
        weaponFactory = new ConcreteWeaponFactory();
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
            Debug.Log(typeofItem.ToString());
            if (typeofItem == typeof(Weapon))
            {
                typeofItem = GenerateLoot(Weapon.weaponTypeList);
                user.myInventory.items.Add(Instantiate(weaponFactory.GetItem(typeofItem.ToString()), lootManager.lootSlots[i].transform));
            }
            else
            {
                user.myInventory.items.Add(Instantiate(itemFactory.GetItem(typeofItem.ToString()), lootManager.lootSlots[i].transform));
            }
        }
        StartCoroutine(DisplayNames());
    }

    public IEnumerator DisplayNames()
    {
        yield return new WaitForSeconds(3.0f);
        for (int j = 0; j < user.myInventory.items.Count; j++)
        {
            Debug.Log(user.myInventory.items[j].ItemName);
        }
    }

    public Type GenerateLoot<T>(List<T> list)
    {
        Type type = randomManager.RandomList(list);
        return type;
    }
   }
