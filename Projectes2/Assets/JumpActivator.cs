using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpActivator : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().jumpOnPaint = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().jumpOnPaint = false;
        }
    }
}
