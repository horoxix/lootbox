using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    const string LEVEL_KEY = "player_level";
    const string GUEST_LOGIN_ID = "guest_login_id";
    const string FB_ACCESS_TOKEN = "fb_login_id";
    const string IS_MUSIC_ON = "is_music_on";
    const string IS_SFX_ON = "is_sfx_on";
    const string LOGGED_IN_USER_ID = "logged_in_user_id";
    const string LOGGED_IN_USER_PASSWORD = "logged_in_user_password";

    // Sets the userID
    public static void SetUserID(string userID)
    {
        PlayerPrefs.SetString(LOGGED_IN_USER_ID, userID);
    }

    // Gets the player userID
    public static string GetUserID()
    {
        return PlayerPrefs.GetString(LOGGED_IN_USER_ID);
    }

    // Sets the password
    public static void SetPassword(string password)
    {
        PlayerPrefs.SetString(LOGGED_IN_USER_PASSWORD, password);
    }

    // Gets the player password
    public static string GetPassword()
    {
        return PlayerPrefs.GetString(LOGGED_IN_USER_PASSWORD);
    }

    // Sets the player level
    public static void SetPlayerLevel(int level)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, level);
    }

    // Gets the player level
    public static int GetPlayerLevel()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY);
    }

    // Sets Music setting
    public static void SetMusicSetting(bool isMusicOn)
    {
        int musicInt = isMusicOn ? 1 : 0;
        PlayerPrefs.SetInt(IS_MUSIC_ON, musicInt);
    }

    //Gets Music setting
    public static bool GetMusicSetting()
    {
        int musicInt = PlayerPrefs.GetInt(IS_MUSIC_ON, -1);
        return musicInt == 1 || musicInt == -1;
    }

    // Toggles SFX Setting.
    public static void SetSFXSetting(bool isSFXOn)
    {
        int sfxInt = isSFXOn ? 1 : 0;
        PlayerPrefs.SetInt(IS_SFX_ON, sfxInt);
    }

    // Gets SFX Setting
    public static bool GetSFXSetting()
    {
        int sfxInt = PlayerPrefs.GetInt(IS_SFX_ON, -1);
        return sfxInt == 1 || sfxInt == -1;
    }
}