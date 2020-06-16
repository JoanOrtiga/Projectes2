using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//este script hace que el enemigo siga al player 
public class FollowPlayer : BossController
{
    Transform playerPos;

    private float maxTimeCd;
    public float PlayerFollowTime;
    public float followPlayerSpeed;
    public bool canMove;
    public BossTurret turret1;
    public BossTurret turret2;
    // Use this for initialization

    public float maxSec = 8, minSec = 4;

    float secondsToChange;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       // canMove = true;
    }

    private void OnEnable()
    {
        secondsToChange = Random.Range(minSec, maxSec);
        turret1.awake = true;
        turret2.awake = true;
    }

    private void FixedUpdate()
    {
        secondsToChange -= Time.deltaTime;

      //  if (canMove)
    //    {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(playerPos.position.x, transform.position.y, 0), followPlayerSpeed * Time.deltaTime);
        //}

        if(secondsToChange <= 0)
        {
            base.changeMov(BossStates.FollowPlayer);
        }
    }
    private void OnDisable()
    {
        turret1.awake = false;
        turret2.awake = false;
    }
}
