using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Time.timeScale = 0f;
        }
        else if (Input.GetButtonUp("Pause"))
        {
           Time.timeScale = 1f;
        }
    }
}
