using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private string levelToLoadName;
   
    /**
	 * Used to load a specific level
	**/
    public void LoadLevel(string name)
    {
        Initiate.Fade(name, Color.black, 1);
    }

    /**
	 * Quits the game
	**/
    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    /**
	 * Loads the next level in the build order
	**/
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
