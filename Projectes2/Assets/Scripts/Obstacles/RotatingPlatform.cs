using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (gameObject.GetComponent<Collider2D>().isTrigger )
        {
            gameObject.transform.rotation = Quaternion.EulerRotation(0, 0, 1);

        }
    }
}
