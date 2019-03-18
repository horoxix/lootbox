using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnModalClick : MonoBehaviour, IPointerDownHandler {

    private EquipmentManager equipmentManager;

    private void Start()
    {
        equipmentManager = FindObjectOfType<EquipmentManager>();
    }

    // Checks for pointer down on modal to hide it.
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    { 
        if (equipmentManager.ModalShown == true)
        {
            equipmentManager.animator.SetBool("SlideIn", false);
            equipmentManager.animator.SetBool("SlideOut", true);
            equipmentManager.ModalShown = false;
        }
    }

    // Sets modal shown to true when it slides out.
    public void SetModalShownTrue()
    {
        equipmentManager.animator.SetBool("ModalShown", true);
        equipmentManager.animator.SetBool("SlideIn", false);
    }

    // Sets modal shown to false when it goes away.
    public void SetModalShownFalse()
    {
        equipmentManager.animator.SetBool("ModalShown", false);
        equipmentManager.animator.SetBool("SlideOut", false);
    }
}
