using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BackgroundSprites {

    public static Dictionary<string, Sprite> backgroundSprites = new Dictionary<string, Sprite>
        {
            { "Common", Resources.Load<Sprite>("rarityBackground/common") },
            { "Uncommon", Resources.Load<Sprite>("rarityBackground/uncommon") },
            { "Rare", Resources.Load<Sprite>("rarityBackground/rare") },
            { "Epic", Resources.Load<Sprite>("rarityBackground/epic") },
            { "Legendary", Resources.Load<Sprite>("rarityBackground/legendary") }
        };
}
