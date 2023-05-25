using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treelevator : MonoBehaviour
{
    // objects
    public GameObject treeBody;
    public GameObject trigger;
    public GameObject tree;
    // parameters
    [SerializeField] float treeGrowSpeed = 1f;
    [SerializeField] float activationTime = 2f; // time to activate in seconds
    public Transform topPosition;

    // variables
    float height;
    Vector2 initialScale;
    Vector2 finalScale;
    Vector2 scaleChange;
    Vector2 initialTopPosition;
    float addheight;

    // activation 
    // desired behavior: after x seconds, grow tree
    bool playerIsOnTop;
    float timeOnTop;
    bool elevatorEnabled;


    float distanceToTop;

    void Awake()
    {
        initialTopPosition = topPosition.position;
        //initialTopPosition.y= topPosition.position.y + treeBody.transform.localScale.y;
        height = topPosition.position.y - treeBody.transform.position.y;
        initialScale = treeBody.transform.localScale;
        
        finalScale = new Vector2(treeBody.transform.localScale.x, topPosition.position.y);
        elevatorEnabled = false;
        timeOnTop = 0;
        addheight = tree.transform.position.y;
    }

    void Start() 
    {

    }

    void Update()
    {
        //trigger.transform.position = new Vector2(treeBody.transform.position.x, treeBody.transform.localScale.y);
        trigger.transform.position = new Vector2(treeBody.transform.position.x, treeBody.transform.localScale.y + addheight);
        distanceToTop = initialTopPosition.y - treeBody.transform.localScale.y -addheight;

        // elevator detection
        CountTimeOnTop();
        EnableElevator();

        // grow if player is on top
        if (elevatorEnabled)
        {
            if (distanceToTop >= 0.001f) {
                treeBody.transform.localScale += (new Vector3(0, treeGrowSpeed, 0)) * Time.deltaTime * 4f;
            }
        }
    }
   
    void CountTimeOnTop()
    {
        if (playerIsOnTop)
        {
            timeOnTop += Time.deltaTime;
        }
        else 
        {
            timeOnTop = 0;
        }
    }

    void EnableElevator()
    {
        if (timeOnTop >= activationTime)
        {
            elevatorEnabled = true;
        }
    }

    public void SetPlayerIsOnTop(bool iPlayerOnTop)
    {
        playerIsOnTop = iPlayerOnTop;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireCube(new Vector2(treeBody.transform.position.x, treeBody.transform.localScale.y), new Vector2(4, 1));
    }
}
