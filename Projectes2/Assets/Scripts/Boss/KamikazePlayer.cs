using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//este script hace que el enemigo ataque al player modo kamikaze
public class KamikazePlayer : BossController
{
    Transform playerPos;
    public float followPlayerSpeed;
    public int KamiKazeDamage;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, followPlayerSpeed * Time.deltaTime);

    }
    protected override void changeMov()
    {
        switch (base.switchMov())
        {
            case BossStates.AtakBarrido:
                GetComponent<AtakBarrido>().enabled = true;
                this.enabled = false;
                break;
            case BossStates.AtakBomb:
                GetComponent<AtakBomb>().enabled = true;
                this.enabled = false;
                break;
            case BossStates.AtakOrbitalStrike:
                GetComponent<AtakOrbitalStrike>().enabled = true;
                this.enabled = false;
                break;
            case BossStates.FollowPlayer:
                GetComponent<FollowPlayer>().enabled = true;
               // FollowPlayer.canMove = false;      Hay que arreglar esto
                this.enabled = false;
                break;

        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().currentHP -= KamiKazeDamage;
            changeMov();
        }
    }
     
}
