using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : MonoBehaviour
{
    public Item attachedItem;
    public EquipmentManager equipmentManager;

    private void OnMouseDown()
    {
        equipmentManager = FindObjectOfType<EquipmentManager>();
        equipmentManager.ToggleCanvas(1);
        equipmentManager.SelectItem(attachedItem);
    }
}
