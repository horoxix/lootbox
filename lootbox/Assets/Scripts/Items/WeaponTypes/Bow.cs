using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon {

    public static Dictionary<string, Sprite> bowSprites = new Dictionary<string, Sprite>
    {
        { "Common", Resources.Load<Sprite>("bows/common") },
        { "Uncommon", Resources.Load<Sprite>("bows/uncommon") },
        { "Rare", Resources.Load<Sprite>("bows/rare") },
        { "Epic", Resources.Load<Sprite>("bows/epic") },
        { "Legendary", Resources.Load<Sprite>("bows/legendary") }
    };

    // Use this for initialization
    protected override void Start () {
        weaponType = WeaponType.BOW;
        GenerateRarity();
        CheckRarity(bowSprites);
        generatedName = name.ToString();
        base.Start();
    }



}
