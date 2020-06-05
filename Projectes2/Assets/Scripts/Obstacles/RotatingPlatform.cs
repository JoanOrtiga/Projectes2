using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    private bool notFreezed = true;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            print(transform.GetChild(0).GetChild(i).name);
            if (transform.GetChild(0).GetChild(i).transform.CompareTag("TimeStop"))
            {
                transform.GetChild(0).GetChild(i).GetComponent<TimeStopPlatform>().reactivateTime.AddListener(Defreeze);
                notFreezed = false;
            }

        }

        if (notFreezed)
            transform.Rotate(new Vector3(0, 0, speed));
    }

    public void Defreeze()
    {
        notFreezed = true;
    }
}
