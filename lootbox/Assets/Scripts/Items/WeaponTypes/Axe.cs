using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon {

    public static Dictionary<string, Sprite> axeSprites = new Dictionary<string, Sprite>
    {
        { "Common", Resources.Load<Sprite>("axes/common") },
        { "Uncommon", Resources.Load<Sprite>("axes/uncommon") },
        { "Rare", Resources.Load<Sprite>("axes/rare") },
        { "Epic", Resources.Load<Sprite>("axes/epic") },
        { "Legendary", Resources.Load<Sprite>("axes/legendary") }
    };

    // Use this for initialization
    protected override void Start () {
        weaponType = WeaponType.AXE;
        GenerateRarity();
        CheckRarity(axeSprites);
        generatedName = name.ToString();
        base.Start();
    }



}
