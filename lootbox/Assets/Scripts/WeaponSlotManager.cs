using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotManager : MonoBehaviour {

    public List<GameObject> weaponSlots;
    public List<Text> modifierSlots;

    [SerializeField]
    public Transform prefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Instantiates inventory slots based on User.user.InventorySlots
    void GenerateWeaponSlots()
    {
        for (int i = 0; i < User.user.WeaponSlots; i++)
        {
            Instantiate(prefab, transform);
        }
    }

    // Adds all inventory slots to a list of inventory slots.
    void SetWeaponSlots()
    {
        foreach (Transform child in transform)
        {
            weaponSlots.Add(child.gameObject);
        }
    }
}
