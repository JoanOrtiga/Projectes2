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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().currentHP -= KamiKazeDamage;
            changeMov(BossStates.KamikazePlayer);
        }
    }
     
}
