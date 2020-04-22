using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraLimit : MonoBehaviour
{
    public UnityEvent cameraTouchedLimit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cameraTouchedLimit.Invoke();
    }
}
