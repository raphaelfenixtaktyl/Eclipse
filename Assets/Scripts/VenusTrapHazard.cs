using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusTrapHazard : MonoBehaviour
{
    public float timeToDrop = 5f;
    private HingeJoint2D hj;
    private JointMotor2D motor;
    private bool isDropping = true;

    // Start is called before the first frame update
    void Start()
    {
        hj = GetComponent<HingeJoint2D>();
        motor = hj.motor;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isDropping)
        {
            StartCoroutine(DropTopMouth());

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isDropping)
        {
            StartCoroutine(RiseTopMouth());
        }

    }

    IEnumerator DropTopMouth()
    {
        yield return new WaitForSeconds(timeToDrop);

        motor.motorSpeed *= -1;
        hj.motor = motor;
        isDropping = false;
    }

    IEnumerator RiseTopMouth()
    {
        yield return new WaitForSeconds(timeToDrop);

        motor.motorSpeed *= -1;
        hj.motor = motor;
        isDropping = true;
    }
}
