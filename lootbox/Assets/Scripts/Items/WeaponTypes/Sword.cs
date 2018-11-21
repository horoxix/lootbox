using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon {

    public static Dictionary<string, Sprite> swordSprites = new Dictionary<string, Sprite>
    {
        { "Common", Resources.Load<Sprite>("swords/common") },
        { "Uncommon", Resources.Load<Sprite>("swords/uncommon") },
        { "Rare", Resources.Load<Sprite>("swords/rare") },
        { "Epic", Resources.Load<Sprite>("swords/epic") },
        { "Legendary", Resources.Load<Sprite>("swords/legendary") }
    };

    // Use this for initialization
    protected override void Start () {
        randomManager = FindObjectOfType<RandomManager>();
        weaponType = WeaponType.SWORD;
        GenerateRarity();
        CheckRarity(swordSprites);
        generatedName = name.ToString();
        base.Start();
	}



}
