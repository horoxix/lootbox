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

    public void RemoveImage()
    {
        Image image = gameObject.GetComponent<Image>();
        image.sprite = null;
        image.enabled = false;
    }

    public void RemoveItem()
    {
        Item item = gameObject.GetComponent<Item>();
        Destroy(item);
    }

    public void Disenchant()
    {
        Item item = gameObject.GetComponent<Item>();
        user.currency += item.value;
        currencyText.text = user.currency.ToString();
        Debug.Log(user.currency);
        RemoveImage();
        RemoveItem();
    }

}
