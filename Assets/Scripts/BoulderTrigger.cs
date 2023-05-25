using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoulderTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent boulderTrigger;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            boulderTrigger.Invoke();
        }
    }
}
