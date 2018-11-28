using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loot : MonoBehaviour {
    private Text currencyText;
    private void Start()
    {
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
        User.user.Currency += item.value;
        currencyText.text = User.user.Currency.ToString();
        RemoveImage();
        RemoveItem();
        HideButtons();
    }

    private void OnMouseDown()
    {
        Image image = gameObject.GetComponent<Image>();
        Item item = gameObject.GetComponent<Item>();
        image.sprite = item.itemSprite;
    }

}
