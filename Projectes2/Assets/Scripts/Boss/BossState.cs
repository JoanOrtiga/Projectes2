using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : MonoBehaviour
{
    protected Rigidbody2D rb2d;

    // Start is called before the first frame update
   
    public  void InitState()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        GetComponent<BossController>().enabled = true;

    }


}
