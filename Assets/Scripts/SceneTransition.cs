using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] Image transitionScreen;
    [SerializeField] int nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadScene();
    }


    public void LoadScene() 
    {
        StartCoroutine(LoadSceneAsync(nextScene));
    }

    IEnumerator LoadSceneAsync(int sceneID)
    {
        int fadeTimerTick = 0;
        for (int i = 0; i < 100; i++)
        {
            fadeTimerTick++;
            transitionScreen.fillAmount = fadeTimerTick * 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        SceneManager.LoadScene(sceneID);
    }
}
