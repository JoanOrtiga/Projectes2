using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeGoDown : MonoBehaviour
{
    private PlatformEffector2D effector;

    public float time1 = 0.15f;
    public float time2 = 0.6f;
    
    private float waitTime;
    private float timer;

    private bool fliper; //como el delfin


    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        timer = time2;
        fliper = false;

        print(fliper + " " + waitTime + " " + timer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            waitTime = time1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = time1;
                fliper = true;
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

                print(fliper + " " + waitTime + " " + timer);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}
