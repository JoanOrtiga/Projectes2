using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : CharHealth
{
    public UnityEvent playerDead;

    public override void RecieveDmg(float dmg)
    {
        base.RecieveDmg(dmg);

        IsDead();
    }

    public override void IsDead()
    {
        if (currentHP < 0)
        {
            playerDead.Invoke();
        }
    }
}
