using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour {
    protected CurrencyType currencyType;

    protected enum CurrencyType
    {
        LBC,
        LIQUID
    }
}
