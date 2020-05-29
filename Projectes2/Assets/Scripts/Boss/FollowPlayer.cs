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
    // Use this for initialization
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        canMove = true;
    }

   

    private void FixedUpdate()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(playerPos.position.x, transform.position.y, 0), followPlayerSpeed * Time.deltaTime);
        }
    }

    protected override void changeMov()
    {
        switch (base.switchMov())
        {
            case BossStates.AtakBarrido:
                GetComponent<AtakBarrido>().enabled = true;
                canMove = false;
                this.enabled = false;
                break;
            case BossStates.AtakBomb:
                GetComponent<AtakBomb>().enabled = true;
                canMove = false;
                this.enabled = false;
                break;
            case BossStates.AtakOrbitalStrike:
                GetComponent<AtakOrbitalStrike>().enabled = true;
                canMove = false;
                this.enabled = false;
                break;
            case BossStates.KamikazePlayer:
                GetComponent<KamikazePlayer>().enabled = true;
                canMove = false;
                this.enabled = false;
                break;

        }
    }
}
