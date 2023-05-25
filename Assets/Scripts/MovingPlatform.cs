using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public int startingPoint;
    public Transform[] points;

    int numPoints;

    int i;
    // Start is called before the first frame update

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        transform.position = points[startingPoint].position;
        numPoints = points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i%numPoints].position) <= 0.02f)
        {
            i++;
            return;
        }

        // move platform to point
        Vector2 direction = (points[i%numPoints].position - transform.position).normalized;
        transform.position = new Vector2(transform.position.x + direction.x * speed * 0.001f, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // // check if player is moveing
        // if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.002f)
        // {
        //     collision.transform.SetParent(transform);
        // }
        // else
        // {
        //     collision.transform.SetParent(null);
        // }
        
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        // collision.transform.SetParent(null);
    }
}
