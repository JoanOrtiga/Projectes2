using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeGoDown : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;


    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            waitTime = 0.15f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("hola");
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;

            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0f;

        }

        if (fliper)
        {
            if (timer <= 0)
            {
                effector.rotationalOffset = 0f;
                fliper = false;
                timer = time2;

            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

    }
}
