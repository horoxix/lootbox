using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {
    private LootBox lootBox;
    private List<Weapon> combatWeaponList;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BattleStart()
    {

    }

    public void ShuffleWeapons()
    {
        for (int i = 0; i < User.user.weapons.Count; i++)
        {
            int j = Random.Range(i, User.user.weapons.Count);
            ItemObject t = User.user.weapons[i];
            User.user.weapons[i] = User.user.weapons[j];
            User.user.weapons[j] = t;
        }
    }
}
