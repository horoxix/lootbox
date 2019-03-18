using System;
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
    private static bool spawned;
    private Firebase.Auth.FirebaseAuth auth;
    private Firebase.Auth.FirebaseUser user;
    private DependencyStatus dependencyStatus;
    private DatabaseReference databaseReference;
    public int LastLootBoxAccumulatedTime;
    private string userId;
    private string logText = "";
    private string username;
    protected string email = "";
    protected string password = "";
    protected string displayName = "";
    const int kMaxLogSize = 16382;
    [SerializeField]
    private InputField usernameField;
    [SerializeField]
    private InputField passwordField;
    [SerializeField]
    private LootManager lootManager;
    [SerializeField]
    private LevelManager levelManager;

    // Spawns firebase and verifies that it is updated.
    private void Awake()
    {
        dependencyStatus = DependencyStatus.UnavailableOther;
        if (spawned == false)
        {
            spawned = true;
            DontDestroyOnLoad(gameObject);
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
                dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    FirebaseApp app = FirebaseApp.DefaultInstance;
                    app.SetEditorDatabaseUrl("https://lootbox-b9a5e.firebaseio.com/");
                    if (app.Options.DatabaseUrl != null) app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
                    databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
                    isInitialized = true;
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

    // Initializes firebase and authentication.
    private void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        Debug.Log(auth);
        AuthStateChanged(this, null);
    }

    // Track state changes of the auth object.
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
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
                GetDataFromDatabase();
                levelManager.LoadLevel("Loot");
            }
        }
    }

    // OnDestroy, destroys authentication.
    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }

    // Sets a username
    public void SetUsername(string username)
    {
        this.username = username;
    }

    // Gets a username
    public string GetUsername()
    {
        return username;
    }

    // Sets an encrypted password.
    public void SetPassword(string password)
    {
        this.password = PasswordEncrypt.Encrypt(password, "password");
    }

    // Gets the decrypted password.
    public string GetPassword(string password)
    {
        return PasswordEncrypt.Decrypt(this.password);
    }

    // Sign in with a new user.
    public async void CreateNewAccount()
    {
        await auth.CreateUserWithEmailAndPasswordAsync(usernameField.text, passwordField.text).ContinueWith(task => {
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

    // Sign in with an existing user.
    public async void SignInWithExisting()
    {
        await auth.SignInWithEmailAndPasswordAsync(usernameField.text, passwordField.text).ContinueWith(task => {
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
            user = task.Result;
            Debug.Log(user.UserId);
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                user.DisplayName, user.UserId);
            userId = user.UserId;
        });
        GetDataFromDatabase();
    }

    void SignOut()
    {
        auth.SignOut();
    }

    // Gets data from the firebase database.
    void GetDataFromDatabase()
    {
        FirebaseDatabase.DefaultInstance
            .GetReference("users/" + userId)
            .GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Faulted" + task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                if(task.Result == null || task.Result.Value == null)
                {
                    Debug.Log("New User");
                    User.user.PlayerName = userId;
                    User.user.Level = 1;
                    User.user.Experience = 0;
                    User.user.LootBoxes = 3;
                    DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    User.user.LastTimeOpenedLootBox = (int)(DateTime.UtcNow - epochStart).TotalSeconds;
                    UpdateDatabaseValues();
                }
                else
                {
                    Debug.Log("Existing User");
                    var results = (IDictionary<string, object>)task.Result.Value;
                    User.user.PlayerName = userId;
                    User.user.Level = Convert.ToInt32(results["level"]);
                    User.user.Experience = Convert.ToInt32(results["experience"]);
                    User.user.LootBoxes = Convert.ToInt32(results["lootBoxes"]);
                    User.user.LastTimeOpenedLootBox = Convert.ToInt32(results["lastLootBoxAccumulated"]);
                    Debug.Log(userId + User.user.Level + User.user.LootBoxes);
                    //DataManager.dataManager.LoadInventory();
                }
                levelManager.LoadLevel("Loot");
            }
        });
    }

    // Updates the database value for all.
    public void UpdateDatabaseValues()
    {
        databaseReference.Child("users").Child(userId).Child("level").SetValueAsync(User.user.Level);
        databaseReference.Child("users").Child(userId).Child("lootBoxes").SetValueAsync(User.user.LootBoxes);
        databaseReference.Child("users").Child(userId).Child("experience").SetValueAsync(User.user.Experience);
    }

    // Updates the database value for level.
    public void UpdateLevel()
    {
        databaseReference.Child("users").Child(userId).Child("level").SetValueAsync(User.user.Level);
    }

    // Updates the database value for loot boxes.
    public void UpdateLootBoxes()
    {
        databaseReference.Child("users").Child(userId).Child("lootBoxes").SetValueAsync(User.user.LootBoxes);
    }

    // Updates the database value for experience.
    public void UpdateExperience()
    {
        databaseReference.Child("users").Child(userId).Child("experience").SetValueAsync(User.user.Experience);
    }

    // Adds a number of loot boxes and sets the LastLootBoxAccumlatedTime to now.
    public void AddLootBox(int lootBoxes)
    {
        User.user.LootBoxes += lootBoxes;
        DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        User.user.LastTimeOpenedLootBox = (int)(DateTime.UtcNow - epochStart).TotalSeconds;
        databaseReference.Child("users").Child(userId).Child("lootBoxes").SetValueAsync(User.user.LootBoxes);
        databaseReference.Child("users").Child(userId).Child("lastLootBoxAccumulated").SetValueAsync(User.user.LastTimeOpenedLootBox);
    }

    // Resets the loot boxes to be maxed out.
    public void ResetLootBoxesBalance()
    {
        User.user.LootBoxes = User.user.MaxLootBoxes;
        DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        User.user.LastTimeOpenedLootBox = (int)(DateTime.UtcNow - epochStart).TotalSeconds;
        databaseReference.Child("users").Child(userId).Child("lootBoxes").SetValueAsync(User.user.LootBoxes);
        databaseReference.Child("users").Child(userId).Child("lastLootBoxAccumulated").SetValueAsync(User.user.LastTimeOpenedLootBox);
    }

    // Updates the last time a loot box was accumulated.
    public void UpdateLastTimeOpenedLootBox()
    {
        DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        User.user.LastTimeOpenedLootBox = (int)(DateTime.UtcNow - epochStart).TotalSeconds;
        databaseReference.Child("users").Child(userId).Child("lastLootBoxAccumulated").SetValueAsync(User.user.LastTimeOpenedLootBox);
    }
}