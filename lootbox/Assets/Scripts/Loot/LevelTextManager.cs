using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTextManager : MonoBehaviour {
    [SerializeField]
    UnityEngine.UI.Text levelText;

    // Use this for initialization
    void Start()
    {
        levelText.text = User.user.Level.ToString();
    }
}
