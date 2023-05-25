using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    // Components
    Rigidbody2D rb;

    // Objects
    [SerializeField] Collider2D triggerCollider;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    public void LaunchBoulder()
    {
        // add force to boulder
        // make customizable
        rb.AddForce(Vector2.right * 60f);
    }
    
}
