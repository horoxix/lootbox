using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSprites {

    public static Dictionary<string, Sprite> swordSprites = new Dictionary<string, Sprite>
        {
            { "Common", Resources.Load<Sprite>("swords/common") },
            { "Uncommon", Resources.Load<Sprite>("swords/uncommon") },
            { "Rare", Resources.Load<Sprite>("swords/rare") },
            { "Epic", Resources.Load<Sprite>("swords/epic") },
            { "Legendary", Resources.Load<Sprite>("swords/legendary") }
        };
    public static Dictionary<string, Sprite> maceSprites = new Dictionary<string, Sprite>
        {
            { "Common", Resources.Load<Sprite>("maces/common") },
            { "Uncommon", Resources.Load<Sprite>("maces/uncommon") },
            { "Rare", Resources.Load<Sprite>("maces/rare") },
            { "Epic", Resources.Load<Sprite>("maces/epic") },
            { "Legendary", Resources.Load<Sprite>("maces/legendary") }
        };
    public static Dictionary<string, Sprite> spearSprites = new Dictionary<string, Sprite>
        {
            { "Common", Resources.Load<Sprite>("spears/common") },
            { "Uncommon", Resources.Load<Sprite>("spears/uncommon") },
            { "Rare", Resources.Load<Sprite>("spears/rare") },
            { "Epic", Resources.Load<Sprite>("spears/epic") },
            { "Legendary", Resources.Load<Sprite>("spears/legendary") }
        };
    public static Dictionary<string, Sprite> bowSprites = new Dictionary<string, Sprite>
        {
            { "Common", Resources.Load<Sprite>("bows/common") },
            { "Uncommon", Resources.Load<Sprite>("bows/uncommon") },
            { "Rare", Resources.Load<Sprite>("bows/rare") },
            { "Epic", Resources.Load<Sprite>("bows/epic") },
            { "Legendary", Resources.Load<Sprite>("bows/legendary") }
        };
    public static Dictionary<string, Sprite> axeSprites = new Dictionary<string, Sprite>
        {
            { "Common", Resources.Load<Sprite>("axes/common") },
            { "Uncommon", Resources.Load<Sprite>("axes/uncommon") },
            { "Rare", Resources.Load<Sprite>("axes/rare") },
            { "Epic", Resources.Load<Sprite>("axes/epic") },
            { "Legendary", Resources.Load<Sprite>("axes/legendary") }
        };
    public static Dictionary<string, Sprite> helmSprites = new Dictionary<string, Sprite>
        {
            { "Common", Resources.Load<Sprite>("helms/common") },
            { "Uncommon", Resources.Load<Sprite>("helms/uncommon") },
            { "Rare", Resources.Load<Sprite>("helms/rare") },
            { "Epic", Resources.Load<Sprite>("helms/epic") },
            { "Legendary", Resources.Load<Sprite>("helms/legendary") }
        };
    public static Dictionary<string, Sprite> glovesSprites = new Dictionary<string, Sprite>
        {
            { "Common", Resources.Load<Sprite>("gloves/common") },
            { "Uncommon", Resources.Load<Sprite>("gloves/uncommon") },
            { "Rare", Resources.Load<Sprite>("gloves/rare") },
            { "Epic", Resources.Load<Sprite>("gloves/epic") },
            { "Legendary", Resources.Load<Sprite>("gloves/legendary") }
        };
    public static Dictionary<string, Sprite> armorSprites = new Dictionary<string, Sprite>
        {
            { "Common", Resources.Load<Sprite>("armor/common") },
            { "Uncommon", Resources.Load<Sprite>("armor/uncommon") },
            { "Rare", Resources.Load<Sprite>("armor/rare") },
            { "Epic", Resources.Load<Sprite>("armor/epic") },
            { "Legendary", Resources.Load<Sprite>("armor/legendary") }
        };
    public static Dictionary<string, Sprite> bootsSprites = new Dictionary<string, Sprite>
        {
            { "Common", Resources.Load<Sprite>("boots/common") },
            { "Uncommon", Resources.Load<Sprite>("boots/uncommon") },
            { "Rare", Resources.Load<Sprite>("boots/rare") },
            { "Epic", Resources.Load<Sprite>("boots/epic") },
            { "Legendary", Resources.Load<Sprite>("boots/legendary") }
        };
    public static Dictionary<string, Sprite> beltsSprites = new Dictionary<string, Sprite>
        {
            { "Common", Resources.Load<Sprite>("belts/common") },
            { "Uncommon", Resources.Load<Sprite>("belts/uncommon") },
            { "Rare", Resources.Load<Sprite>("belts/rare") },
            { "Epic", Resources.Load<Sprite>("belts/epic") },
            { "Legendary", Resources.Load<Sprite>("belts/legendary") }
        };
    public static Dictionary<string, Sprite> accessorySprites = new Dictionary<string, Sprite>
        {
            { "Common", Resources.Load<Sprite>("accessories/common") },
            { "Uncommon", Resources.Load<Sprite>("accessories/uncommon") },
            { "Rare", Resources.Load<Sprite>("accessories/rare") },
            { "Epic", Resources.Load<Sprite>("accessories/epic") },
            { "Legendary", Resources.Load<Sprite>("accessories/legendary") }
        };
    public static Dictionary<string, Sprite> pantsSprites = new Dictionary<string, Sprite>
        {
            { "Common", Resources.Load<Sprite>("pants/common") },
            { "Uncommon", Resources.Load<Sprite>("pants/uncommon") },
            { "Rare", Resources.Load<Sprite>("pants/rare") },
            { "Epic", Resources.Load<Sprite>("pants/epic") },
            { "Legendary", Resources.Load<Sprite>("pants/legendary") }
        };
}
