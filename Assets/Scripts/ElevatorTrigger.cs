using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public bool isPlayerStep;
    public float maxHeight;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPlayerStep = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPlayerStep = false;
    }
    private void Start()
    {
        isPlayerStep = false;
    }

    void Update()
    {
        if (isPlayerStep)
        {
            if (this.transform.localPosition.y >= maxHeight)
                return;
            else
            {
                this.transform.Translate(0, Time.deltaTime + 0.01f, 0, Space.Self);
                Debug.Log("Moving Up");
            }
                
        }
        else if (!isPlayerStep)
        {
            if (this.transform.localPosition.y <= 0)
            {
                this.transform.localPosition = Vector3.zero;
                return;
            }
            else
            {
                this.transform.Translate(0, -Time.deltaTime - 0.01f, 0, Space.Self);
                Debug.Log("Moving Down");
            }
                


            
        }
    }
}
