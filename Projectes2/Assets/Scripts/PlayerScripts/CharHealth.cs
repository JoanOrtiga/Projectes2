using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharHealth : MonoBehaviour
{
   // [HideInInspector]
    public float currentHP;

    public float maxHP;

    private void Start()
    {
        currentHP = maxHP;
    }

    public virtual void RecieveDmg(float dmg)
    {
        currentHP -= dmg;
    }

    public virtual void IsDead()
    {

    }

    public void RecieveHeal(float moreHealth)
    {
        currentHP += moreHealth;
    }
}
