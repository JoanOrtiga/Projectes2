using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    public float speed;
    public float maxSize;

    public bool notFreezed = true;

    private void FixedUpdate()
    {
        if (notFreezed)
        {
            Vector3 vec = new Vector3(1, maxSize * Mathf.Abs((Mathf.Sin(Time.time * speed))), 1);
            transform.localScale = vec;
        }
            
    }

    private void Update()
    {
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            if (transform.GetChild(0).GetChild(i).transform.CompareTag("TimeStop"))
            {
                transform.GetChild(0).GetChild(i).GetComponent<TimeStopPlatform>().reactivateTime.AddListener(Defreeze);
                notFreezed = false;
            }
        }
    }

    public void Defreeze()
    {
        notFreezed = true;
    }
}
