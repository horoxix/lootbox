using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour {
    [SerializeField]
    UnityEngine.UI.Text currencyText;

	// Use this for initialization
	void Start () {
        currencyText.text = User.user.Currency.ToString();
	}
	
}
