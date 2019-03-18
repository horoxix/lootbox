using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItem {
    private ItemObject attachedItem;

    public ItemObject AttachedItem
    {
        get
        {
            return attachedItem;
        }

        set
        {
            attachedItem = value;
        }
    }
}
