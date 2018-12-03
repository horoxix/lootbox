using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RaritySprites {

    public static Dictionary<string, Sprite> raritySprites = new Dictionary<string, Sprite>
        {
            { "Common", Resources.Load<Sprite>("rarity/common") },
            { "Uncommon", Resources.Load<Sprite>("rarity/uncommon") },
            { "Rare", Resources.Load<Sprite>("rarity/rare") },
            { "Epic", Resources.Load<Sprite>("rarity/epic") },
            { "Legendary", Resources.Load<Sprite>("rarity/legendary") }
        };
}
