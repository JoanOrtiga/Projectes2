using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : CharHealth
{
    public UnityEvent playerDead;
    public int damage;
    public override void RecieveDmg(float dmg)
    {
        currentHP -= dmg;

        IsDead();
    }

    public override void IsDead()
    {
        if (currentHP < 0)
        {
            playerDead.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().currentHP -= damage*Time.deltaTime;
        }
    }

    private void Update()
    {
        IsDead();
    }
}
