using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtakBomb : BossController
{
    public GameObject projectile;
    public float fireDelay;
    private float fireDelaySeconds;

    public GameObject bombShooter;
    public GameObject bomb;
    

    private void Update()
    {
        fireDelaySeconds -= Time.deltaTime;
        if (fireDelaySeconds <= 0)
        {
            fire();
            fireDelaySeconds = fireDelay;
        }
        
       
    }


    void fire()
    {
        Instantiate(bomb, bombShooter.transform.position, Quaternion.identity);
     
    }

}
