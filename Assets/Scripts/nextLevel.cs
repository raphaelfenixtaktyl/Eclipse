using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public float levelLoadDelay;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PlayNext());
        }
    }

    IEnumerator PlayNext()
    {
        yield return new WaitForSeconds(levelLoadDelay);
        SceneManager.LoadScene("MountainScene");
        //LevelManager.GetInstance().ContinueToNext();
    }
}
