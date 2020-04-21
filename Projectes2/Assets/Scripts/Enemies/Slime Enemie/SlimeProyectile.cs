using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeProyectile : MonoBehaviour
{
    public float destroyTime = 5;
    void Update()
    {
        Destroy(this.gameObject, destroyTime);


    }
}
