using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour {
    FirebaseManager firebaseManager;

    public void levelUp(Text text)
    {
        User.user.Level += 1;
        User.user.LootBoxes += 1;
        User.user.ExperienceToNext = User.user.Level * 100;
        User.user.Experience = User.user.ExperienceToNext - User.user.Experience;
        text.text = User.user.Level.ToString();
        firebaseManager = FindObjectOfType<FirebaseManager>();
        if(!firebaseManager)
        {
            Debug.LogError(gameObject + " couldn't find FirebaseManager");
        }
        UpdateDatabase();
    }

    private void UpdateDatabase()
    {
        firebaseManager.Level = User.user.Level;
        firebaseManager.Experience = User.user.Experience;
        firebaseManager.LootBoxes = User.user.LootBoxes;
        firebaseManager.UpdateDatabaseValues();
    }
}
