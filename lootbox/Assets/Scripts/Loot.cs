using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loot : MonoBehaviour {
    private User user;
    private Text currencyText;
    private void Start()
    {
        user = FindObjectOfType<User>();
        currencyText = FindObjectOfType<Currency>().GetComponent<Text>();
    }

    // Removes Loot Image in UI
    public void RemoveImage()
    {
        Image image = gameObject.GetComponent<Image>();
        image.sprite = null;
        image.enabled = false;
        HideButtons();
    }

    // Destroys component of loot
    public void RemoveItem()
    {
        Item item = gameObject.GetComponent<Item>();
        Destroy(item);
    }

    // Hides disenchant and send to inventory buttons
    public void HideButtons()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Disenchants based on item's value and adds to user.currency
    public void Disenchant()
    {
        Item item = gameObject.GetComponent<Item>();
        user.currency += item.value;
        currencyText.text = user.currency.ToString();
        RemoveImage();
        RemoveItem();
        HideButtons();
    }

}
