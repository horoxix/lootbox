using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    const string LEVEL_KEY = "player_level";
    const string GUEST_LOGIN_ID = "guest_login_id";
    const string FB_ACCESS_TOKEN = "fb_login_id";
    const string IS_MUSIC_ON = "is_music_on";
    const string IS_SFX_ON = "is_sfx_on";

  
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