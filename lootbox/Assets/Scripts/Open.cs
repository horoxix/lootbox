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
    private StatFactory statFactory;

    private void Start()
    {
        user = FindObjectOfType<User>();
        itemFactory = new ConcreteItemFactory();
        weaponFactory = new ConcreteWeaponFactory();
        statFactory = new ConcreteStatFactory();
        randomManager = FindObjectOfType<RandomManager>();
    }

    // On click to OpenBox, looks at how many items are in the box and adds an Item.
    // TODO : In UI, add item to specific gameObjects.
    public void OpenBox(LootBox lootBox)
    {
        for(int i=0; i < lootBox.ItemCount; i++)
        {
            Item.ItemType itemType = GenerateItemType();
            GameObject thisObject = lootManager.lootSlots[i].gameObject;
            Image uiSprite = thisObject.GetComponent<Image>();
            if (itemType == Item.ItemType.WEAPON)
            {
                Weapon weapon = weaponFactory.Create(GenerateWeaponType());
                Weapon addedWeapon = thisObject.AddComponent(weapon.GetType()) as Weapon;
                addedWeapon.Instantiate(weapon.weaponType, weapon.rarity, weapon.itemSprite, weapon.itemName);
                user.myInventory.items.Add(addedWeapon);
                uiSprite.sprite = addedWeapon.itemSprite;
                uiSprite.enabled = true;
                thisObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                Item item = itemFactory.GetItem(itemType);
                Item addedItem = thisObject.AddComponent(item.GetType()) as Item;
                addedItem.Instantiate(item.itemType, item.rarity, item.itemSprite, item.itemName, statFactory.GenerateStatAmount(addedItem.rarity));
                user.myInventory.items.Add(addedItem);
                uiSprite.sprite = addedItem.itemSprite;
                uiSprite.enabled = true;
                thisObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        StartCoroutine(DisplayNames());
    }

    public IEnumerator DisplayNames()
    {
        yield return new WaitForSeconds(1.0f);
        for (int j = 0; j < user.myInventory.items.Count; j++)
        {
            Debug.Log(user.myInventory.items[j].itemName);
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
