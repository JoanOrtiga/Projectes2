using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraLimit : MonoBehaviour
{
    public Transform limit1;
    public Transform limit2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Camera.main.GetComponent<CameraController>().NewRoom(limit1.position, limit2.position);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Camera.main.GetComponent<CameraController>().NewRoom(limit1.position, limit2.position);
        }
    }
}
