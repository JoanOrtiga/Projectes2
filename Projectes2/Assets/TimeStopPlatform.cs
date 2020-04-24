using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TimeStopPlatform : MonoBehaviour
{
    public UnityEvent reactivateTime;

    private void Start()
    {
        StartCoroutine(destroy());
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(1.5f);

        reactivateTime.Invoke();
        Destroy(this.gameObject);
    }
}
