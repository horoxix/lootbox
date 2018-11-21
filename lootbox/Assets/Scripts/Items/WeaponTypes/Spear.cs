using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon {

    public static Dictionary<string, Sprite> spearSprites = new Dictionary<string, Sprite>
    {
        { "Common", Resources.Load<Sprite>("spears/common") },
        { "Uncommon", Resources.Load<Sprite>("spears/uncommon") },
        { "Rare", Resources.Load<Sprite>("spears/rare") },
        { "Epic", Resources.Load<Sprite>("spears/epic") },
        { "Legendary", Resources.Load<Sprite>("spears/legendary") }
    };

    // Use this for initialization
    protected override void Start () {
        weaponType = WeaponType.SPEAR;
        GenerateRarity();
        CheckRarity(spearSprites);
        generatedName = name.ToString();
        base.Start();
    }



}
