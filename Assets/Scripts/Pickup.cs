using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Movement move;

    private void Start()
    {
       move = FindObjectOfType<Movement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            move.hasDashed = false;
            move.isDashing = false;
            //Destroy(gameObject);
        }
    }
}
