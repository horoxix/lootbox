using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootBoxAccumulationManager : MonoBehaviour {
    private readonly int FIFTEEN_MINUTES = 900;
    private int lastLootBoxTime;
    private int timeTillNextLootBox;
    private bool notAtMaxLootBoxes;
    private FirebaseManager firebaseManager;
    [SerializeField]
    Text timeRemainingText;
    [SerializeField]
    Text lootBoxesText;

    public static LootBoxAccumulationManager lbam;

    // Initializes lbam and sets to self.
    private void Awake()
    {
        if (lbam == null)
        {
            DontDestroyOnLoad(gameObject);
            lbam = this;
        }
        else if (lbam != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        firebaseManager = FindObjectOfType<FirebaseManager>();
        lootBoxesText.text = User.user.LootBoxes.ToString();
        if (!firebaseManager)
        {
            Debug.LogError(gameObject + " couldn't find FirebaseManager");
        }
        else
        {
            if (User.user.LootBoxes < User.user.MaxLootBoxes)
            {
                notAtMaxLootBoxes = true;
                GenerateLootBoxesWhileNotPlaying();
            }
        }
    }

    // Updates timer, checks for using loot boxes. counts down FIFTEEN_MINUTES
    void FixedUpdate()
    {
        if (!notAtMaxLootBoxes)
        {
            if(User.user.LootBoxes < User.user.MaxLootBoxes)
            {
                notAtMaxLootBoxes = true;
            }
            else
            {
                return;
            }
        }
        DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int current_time = (int)(DateTime.UtcNow - epochStart).TotalSeconds;
        int difference = current_time - User.user.LastTimeOpenedLootBox;
        if(lootBoxesText)
        {
            lootBoxesText.text = User.user.LootBoxes.ToString();
        }
        if (timeRemainingText)
        {
            timeRemainingText.text = ConvertSecondsToMinutes(FIFTEEN_MINUTES - difference).ToString();
        }
        if (difference >= FIFTEEN_MINUTES)
        {
            firebaseManager.AddLootBox(1);
            lootBoxesText.text = User.user.LootBoxes.ToString();
            if (User.user.LootBoxes >= User.user.MaxLootBoxes)
            {
                notAtMaxLootBoxes = false;
                timeRemainingText.enabled = false;
                User.user.LootBoxes = User.user.MaxLootBoxes;
                firebaseManager.ResetLootBoxesBalance();
            }
            else
            {
                timeTillNextLootBox += FIFTEEN_MINUTES;
                timeRemainingText.enabled = true;
                User.user.LastTimeOpenedLootBox = current_time;
            }
        }
    }

    // Generates loot boxes to give to player while not playing.
    public void GenerateLootBoxesWhileNotPlaying()
    {
        DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int current_time = (int)(DateTime.UtcNow - epochStart).TotalSeconds;

        int difference = current_time - User.user.LastTimeOpenedLootBox;
        if (difference >= FIFTEEN_MINUTES)
        {
            User.user.LastTimeOpenedLootBox = current_time;
            int newLootBoxes = difference % FIFTEEN_MINUTES;
            Debug.Log("Loot Boxes : " + newLootBoxes);
            User.user.LootBoxes += newLootBoxes;
            firebaseManager.AddLootBox(newLootBoxes);
            if (User.user.LootBoxes >= User.user.MaxLootBoxes)
            {
                notAtMaxLootBoxes = false;
                User.user.LootBoxes = User.user.MaxLootBoxes;
                firebaseManager.ResetLootBoxesBalance();
            }
            lootBoxesText.text = User.user.LootBoxes.ToString();
        }
    }

    // Converts seconds to minutes for display.
    private string ConvertSecondsToMinutes(int seconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(seconds);
        string str = String.Format("{0:0}:{1:00}", Mathf.Floor(seconds / 60), seconds % 60);
        return str;
    }
}
