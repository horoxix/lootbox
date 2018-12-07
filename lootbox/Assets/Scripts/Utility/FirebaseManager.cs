﻿using System;
using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FirebaseManager : MonoBehaviour
{
    private bool isInitialized;
    private bool spawned;
    private FirebaseApp app;
    private Firebase.Auth.FirebaseAuth auth;
    private Firebase.Auth.FirebaseUser user;
    private DependencyStatus dependencyStatus;
    private DatabaseReference databaseReference;
    private string userId;
    private string username;
    private string password;
    [SerializeField]
    private InputField usernameField;
    [SerializeField]
    private InputField passwordField;
    [SerializeField]
    private LootManager lootManager;
    [SerializeField]
    private LevelManager levelManager;

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
                    InitializeFirebase();
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

    private void InitializeFirebase()
    {
        app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl("https://lootbox-b9a5e.firebaseio.com/");
        if (app.Options.DatabaseUrl != null) app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
        isInitialized = true;
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        Debug.Log("SUCCESS");
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
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

    // Track state changes of the auth object.
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        Debug.Log(auth.CurrentUser);
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                userId = user.UserId;
                Debug.Log("Signed in " + user.UserId);
            }
        }
    }

    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }

    public void SetUsername(string username)
    {
        this.username = username;
    }

    public void SetPassword(string password)
    {
        this.password = PasswordEncrypt.Encrypt(password, "password");
    }

    public string GetPassword(string password)
    {
        return PasswordEncrypt.Decrypt(this.password);
    }


    public void CreateNewAccount()
    {
        auth.CreateUserWithEmailAndPasswordAsync(usernameField.text, passwordField.text).ContinueWith(task => {
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
        GetDataFromDatabase();
    }

    public void SignInWithExisting()
    {
        auth.SignInWithEmailAndPasswordAsync(usernameField.text, passwordField.text).ContinueWith(task => {
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
            Debug.Log(userId);
        });
        GetDataFromDatabase();
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
                Debug.Log("Faulted" + task.Exception);
            }
            else if (task.IsCompleted)
            {
                if(task.Result == null || task.Result.Value == null)
                {
                    Debug.Log("New User");
                    User.user.Level = 1;
                    User.user.Experience = 0;
                    User.user.LootBoxes = 3;
                    UpdateDatabaseValues();
                }
                else
                {
                    Debug.Log("Existing User");
                    var results = (IDictionary<string, object>)task.Result.Value;
                    User.user.Level = Convert.ToInt32(results["level"]);
                    User.user.Experience = Convert.ToInt32(results["experience"]);
                    User.user.LootBoxes = Convert.ToInt32(results["lootBoxes"]);
                }
            }
        });
        
    }

    public void UpdateDatabaseValues()
    {
        databaseReference.Child("users").Child(userId).Child("level").SetValueAsync(User.user.Level);
        databaseReference.Child("users").Child(userId).Child("lootBoxes").SetValueAsync(User.user.LootBoxes);
        databaseReference.Child("users").Child(userId).Child("experience").SetValueAsync(User.user.Experience);
    }

    public void UpdateLevel()
    {
        databaseReference.Child("users").Child(userId).Child("level").SetValueAsync(User.user.Level);
    }

    public void UpdateLootBoxes()
    {
        databaseReference.Child("users").Child(userId).Child("lootBoxes").SetValueAsync(User.user.LootBoxes);
    }

    public void UpdateExperience()
    {
        databaseReference.Child("users").Child(userId).Child("experience").SetValueAsync(User.user.Experience);
    }

}