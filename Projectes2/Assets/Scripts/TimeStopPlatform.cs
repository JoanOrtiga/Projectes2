﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TimeStopPlatform : MonoBehaviour
{
    public float TimeToReactivate = 8f;

    public UnityEvent reactivateTime;

    private void Start()
    {
        StartCoroutine(destroy());
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(TimeToReactivate);

        reactivateTime.Invoke();
        Destroy(this.gameObject);
    }
}