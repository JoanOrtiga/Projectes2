using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    public float speed;
    public float maxSize;

    private void FixedUpdate()
    {
        Vector3 vec = new Vector3(1, maxSize * Mathf.Abs((Mathf.Sin(Time.time * speed))), 1);

        transform.localScale = vec;
    }
}
