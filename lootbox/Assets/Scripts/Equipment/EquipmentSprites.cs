using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipmentSprites {

    public static Dictionary<string, Sprite> equipmentSprites = new Dictionary<string, Sprite>
        {
            { "Weapon", Resources.Load<Sprite>("equipmentBackgrounds/weapon") },
            { "Accessory", Resources.Load<Sprite>("equipmentBackgrounds/accessory") },
            { "Boots", Resources.Load<Sprite>("equipmentBackgrounds/boots") },
            { "Pants", Resources.Load<Sprite>("equipmentBackgrounds/pants") },
            { "Helm", Resources.Load<Sprite>("equipmentBackgrounds/helm") },
            { "Gloves", Resources.Load<Sprite>("equipmentBackgrounds/gloves") },
            { "Armor", Resources.Load<Sprite>("equipmentBackgrounds/armor") }
        };
}
