using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreelevatorTrigger : MonoBehaviour
{
    // Objects
    public Treelevator treelavator;

    void Awake()
    {
        //treelavator = GetComponentInParent<Treelevator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("player is standing on elevator");
            treelavator.SetPlayerIsOnTop(true);
        }
    }
  /*  void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("player is standing on elevator");
            treelavator.SetPlayerIsOnTop(true);
        }
    }*/
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("player left the elevator");
            treelavator.SetPlayerIsOnTop(false);
        }
    }
}
