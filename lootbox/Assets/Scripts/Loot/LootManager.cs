using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootManager : MonoBehaviour {
    public List<GameObject> lootSlots;
    [SerializeField]
    Text playerLevelText;
    [SerializeField]
    Text ExperienceText;
    [SerializeField]
    Text lootBoxesText;
    [SerializeField]
    Text userNameText;

    // Use this for initialization
    void Start () {
		foreach (Transform child in transform)
        {
            lootSlots.Add(child.gameObject);
        }
    }

    private void Update()
    {
        playerLevelText.text = User.user.Level.ToString();
        //lootBoxesText.text = User.user.LootBoxes.ToString();
        ExperienceText.text = User.user.Experience.ToString();
        userNameText.text = User.user.PlayerName.ToString();
    }
}
