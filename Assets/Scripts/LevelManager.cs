using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Level Manager in the scene");
        }
        instance = this;
    }

    public void ContinueToNext()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 2;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    public static LevelManager GetInstance()
    {
        return instance;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene(1);
    }

    public void BackHome ()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game..");
        Application.Quit();
    }
}
