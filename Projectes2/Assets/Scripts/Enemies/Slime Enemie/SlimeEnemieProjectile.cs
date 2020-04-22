using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemieProjectile : MonoBehaviour
{
    public Transform throwPoint;
    private Transform playerTarget;
    public GameObject projectile;
    public float timeTilHit = 3f;

    public float xVelo, yVelo;

    
    void Start()
    {
        playerTarget = GameObject.Find("Player").transform;
        
    }

    public void AttackState(bool state)
    {
        if (state == true) //enter
        {
            InvokeRepeating("Trow", 0.2f, timeTilHit);
        }
        else if (state == false) //exit
        {
            CancelInvoke();
        }
        
    }



   

    void Trow()
    {

        float xdistance;
        xdistance = playerTarget.position.x - throwPoint.position.x;

        float ydistance;
        ydistance = playerTarget.position.y - throwPoint.position.y;

        float trowAngle;

        trowAngle = Mathf.Atan((ydistance + 4.905f) / xdistance);

        float totalvelo = xdistance / Mathf.Cos(trowAngle);

        xVelo = totalvelo * Mathf.Cos(trowAngle);
        yVelo = totalvelo * Mathf.Sin(trowAngle);

        GameObject bulletInstace  = Instantiate(projectile, throwPoint.position, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
        Rigidbody2D rd;
        rd = bulletInstace.GetComponent<Rigidbody2D>();

        rd.velocity = new Vector2(xVelo, yVelo);
    }
}
