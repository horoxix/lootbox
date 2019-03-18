using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : MonoBehaviour
{
    public ItemObject attachedItem;
    public EquipmentManager equipmentManager;

    // Slides in item information on click of equipment slot.
    private void OnMouseDown()
    {
        equipmentManager = FindObjectOfType<EquipmentManager>();
        if (attachedItem != null && equipmentManager.ModalShown == false)
        {
            equipmentManager.SelectItem(attachedItem);
            equipmentManager.animator.SetBool("SlideIn", true);
            equipmentManager.animator.SetBool("ModalShown", false);
            equipmentManager.ModalShown = true;
        }
    }
}
