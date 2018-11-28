using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open : MonoBehaviour {
    [SerializeField]
    GameObject Loot;
    [SerializeField]
    LootManager lootManager;
    private ItemFactory itemFactory;
    private WeaponFactory weaponFactory;
    private StatFactory statFactory;

    private void Start()
    {
        itemFactory = new ConcreteItemFactory();
        weaponFactory = new ConcreteWeaponFactory();
        statFactory = new ConcreteStatFactory();
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
                thisObject.AddComponent<Weapon>();
                Weapon weapon = weaponFactory.Create(GenerateWeaponType(), thisObject);
                User.user.inventory.Add(weapon);
                uiSprite.sprite = weapon.itemSprite;
                uiSprite.enabled = true;
                thisObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                thisObject.AddComponent<Item>();
                Item item = itemFactory.GetItem(itemType, thisObject);
                User.user.inventory.Add(item);
                uiSprite.sprite = item.itemSprite;
                uiSprite.enabled = true;
                thisObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        StartCoroutine(DisplayNames());
    }

    public IEnumerator DisplayNames()
    {
        yield return new WaitForSeconds(1.0f);
        for (int j = 0; j < User.user.inventory.Count; j++)
        {
            Debug.Log(User.user.inventory[j].itemName);
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
