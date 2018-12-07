using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp  {
    FirebaseManager firebaseManager;

    public void IncreaseLevel(Text text, FirebaseManager firebaseManager)
    {
        User.user.Level += 1;
        User.user.LootBoxes += 1;
        User.user.ExperienceToNext = User.user.Level * 100;
        User.user.Experience = User.user.ExperienceToNext - User.user.Experience;
        text.text = User.user.Level.ToString();
        firebaseManager.UpdateDatabaseValues();
    }
}
