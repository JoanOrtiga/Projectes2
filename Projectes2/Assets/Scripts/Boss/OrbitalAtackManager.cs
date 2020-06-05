using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalAtackManager : MonoBehaviour
{
    private float time;
    private void Start()
    {
        time = 2;
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
