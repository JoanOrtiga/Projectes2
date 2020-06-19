using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//este script hace que el enemigo ataque al player modo kamikaze
public class KamikazePlayer : BossController
{
    Transform playerPos;
    public float followPlayerSpeed;
    public int KamikazeDamage;
    private bool active;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    private void OnEnable()
    {
        active = true;
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, followPlayerSpeed * Time.deltaTime);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (active) { 
            other.gameObject.GetComponent<PlayerHealth>().currentHP -= KamikazeDamage;


                ChangeState();
            }
        }
    }
    private void OnDisable()
    {
        active = false;
    }
    public void ChangeState()
    {
        changeMov(BossStates.KamikazePlayer);

    }

}
