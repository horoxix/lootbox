using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open : MonoBehaviour {
    [SerializeField]
    GameObject Loot;
    private User user;
    [SerializeField]
    LootManager lootManager;
    private RandomManager randomManager;
    private ItemFactory itemFactory;
    private WeaponFactory weaponFactory;

    private void Start()
    {
        user = FindObjectOfType<User>();
        itemFactory = new ConcreteItemFactory();
        weaponFactory = new ConcreteWeaponFactory();
        randomManager = FindObjectOfType<RandomManager>();
    }

    // On click to OpenBox, looks at how many items are in the box and adds an Item.
    // TODO : In UI, add item to specific gameObjects.
    public void OpenBox(LootBox lootBox)
    {
        for(int i=0; i < lootBox.ItemCount; i++)
        {
            Item.ItemType itemType = GenerateItemType();
            if (itemType == Item.ItemType.WEAPON)
            {
                Weapon.WeaponType weaponType = GenerateWeaponType();
                Weapon weapon = weaponFactory.Create(weaponType);
                user.myInventory.items.Add(weapon);
                lootManager.lootSlots[i].gameObject.GetComponent<Image>().sprite = weapon.itemSprite;
            }
            else
            {
                Item item = itemFactory.GetItem(itemType);
                user.myInventory.items.Add(item);
                lootManager.lootSlots[i].gameObject.GetComponent<Image>().sprite = item.itemSprite;
            }
        }
        StartCoroutine(DisplayNames());
    }

    public IEnumerator DisplayNames()
    {
        yield return new WaitForSeconds(1.0f);
        for (int j = 0; j < user.myInventory.items.Count; j++)
        {
            Debug.Log(user.myInventory.items[j].generatedName);
        }
    }

    public Item.ItemType GenerateItemType()
    {
        Item.ItemType itemType = (Item.ItemType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Item.ItemType)).Length);
        return itemType;
    }

    public Weapon.WeaponType GenerateWeaponType()
    {
        Weapon.WeaponType weaponType = (Weapon.WeaponType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Weapon.WeaponType)).Length);
        return weaponType;
    }
}
