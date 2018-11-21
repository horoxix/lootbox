using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : Weapon {

    public static Dictionary<string, Sprite> maceSprites = new Dictionary<string, Sprite>
    {
        { "Common", Resources.Load<Sprite>("maces/common") },
        { "Uncommon", Resources.Load<Sprite>("maces/uncommon") },
        { "Rare", Resources.Load<Sprite>("maces/rare") },
        { "Epic", Resources.Load<Sprite>("maces/epic") },
        { "Legendary", Resources.Load<Sprite>("maces/legendary") }
    };

    // Use this for initialization
    protected override void Start () {
        weaponType = WeaponType.MACE;
        GenerateRarity();
        CheckRarity(maceSprites);
        generatedName = name.ToString();
        base.Start();
    }



}
