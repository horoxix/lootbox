using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxesTextManager : MonoBehaviour {
    [SerializeField]
    UnityEngine.UI.Text lootText;

    // Use this for initialization
    void Start()
    {
        lootText.text = User.user.LootBoxes.ToString();
    }
}
