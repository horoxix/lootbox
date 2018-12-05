using System;
using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;

public class FirebaseManager : MonoBehaviour
{
    private bool isInitialized;
    private bool spawned;
    private FirebaseApp app;
    private Firebase.Auth.FirebaseAuth auth;
    private Firebase.Auth.FirebaseUser user;
    private DependencyStatus dependencyStatus;
    private DatabaseReference databaseReference;
    private int lootBoxes;
    private int level;
    private int experience;
    private string userId;

    private void Awake()
    {
        if (spawned == false)
        {
            spawned = true;
            DontDestroyOnLoad(gameObject);
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
                dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    app = FirebaseApp.DefaultInstance;
                    app.SetEditorDatabaseUrl("https://lootbox-b9a5e.firebaseio.com/");
                    if (app.Options.DatabaseUrl != null) app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
                    isInitialized = true;
                    databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
                    auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
                    Debug.Log("SUCCESS");
                }
                else
                {
                    Debug.LogError(string.Format(
                      "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                }
            });
            
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Start");
        app.SetEditorDatabaseUrl("https://lootbox-b9a5e.firebaseio.com/");
        app.SetEditorP12FileName("lootbox-b9a5e-2ebbd35405ef.p12");
        app.SetEditorServiceAccountEmail("horoxix@lootbox-b9a5e.iam.gserviceaccount.com");
        app.SetEditorP12Password("notasecret");
    }

    //Initializes Firebase and checks version for update.
    void InitializeFirebase()
    {
        
    }

    void CreateNewAccount(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            user = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                user.DisplayName, user.UserId);
            userId = user.UserId;
        });
    }

    void SignInWithExisting(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            Firebase.Auth.FirebaseUser user = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                user.DisplayName, user.UserId);
            userId = user.UserId;
        });
    }

    void SignOut()
    {
        auth.SignOut();
    }

    void GetDataFromDatabase()
    {
        FirebaseDatabase.DefaultInstance
            .GetReference("users/" + userId)
            .GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Faulted");
            }
            else if (task.IsCompleted)
            {
                if(task.Result == null || task.Result.Value == null)
                {
                    Debug.Log("New User");
                    level = 1;
                    experience = 0;
                    lootBoxes = 1;
                    UpdateDatabaseValues();
                }
                else
                {
                    Debug.Log("Existing User");
                    var results = (IDictionary<string, object>)task.Result.Value;
                    level = Convert.ToInt32(results["level"]);
                    experience = Convert.ToInt32(results["experience"]);
                    lootBoxes = Convert.ToInt32(results["lootBoxes"]);
                }
            }
        });
    }

    private void UpdateDatabaseValues()
    {
        databaseReference.Child("users").Child(userId).Child("level").SetValueAsync(level);
        databaseReference.Child("users").Child(userId).Child("lootBoxes").SetValueAsync(lootBoxes);
        databaseReference.Child("users").Child(userId).Child("experience").SetValueAsync(experience);
    }

}