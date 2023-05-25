using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //[Header("Visual Cue")]
    //[SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Cutscene")]
    [SerializeField] private bool isCutScene;

    private bool playerInRange;

    private void Awake() 
    {
        playerInRange = false;
        //visualCue.SetActive(false);
    }

    private void Start()
    {
        if (isCutScene)
        {
            PlayScene(inkJSON);
        }
    }

    private void Update() 
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying) 
        {
            //visualCue.SetActive(true);
            if (Input.GetButton("Submit")) 
            {
                PlayScene(inkJSON);
            }
        }
        /*else 
        {
            visualCue.SetActive(false);
        }*/
    }

    private void PlayScene(TextAsset inkJSON)
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, isCutScene);
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
