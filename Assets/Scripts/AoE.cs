using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoE : MonoBehaviour
{
    //public float burnRadius;
    float burnRadius = 4f;
    Collider2D[] collisions;
    public LayerMask layers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        collisions = Physics2D.OverlapCircleAll(transform.position, burnRadius, layers);

        if (collisions.Length > 0)
        {
            foreach (Collider2D collider in collisions)
            {
                Debug.Log("Burning");
            }
        }

        
    }

    // private IEnumerator burnRoutine()
    // {

    // }

    private void OnDrawGizmos()
    {
        if (collisions.Length > 0)
        {
             Gizmos.color = Color.red;
        }
        else
        {
             Gizmos.color = Color.yellow;
        }
       
        Gizmos.DrawWireSphere(transform.position, burnRadius);
    }
}

