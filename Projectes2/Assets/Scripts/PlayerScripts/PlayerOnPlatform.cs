using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlatformMoving"))
        {
            transform.parent = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlatformMoving"))
        {
            print("hola");
            transform.parent = null;
        }
    }
}
