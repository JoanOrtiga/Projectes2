using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharHealth : MonoBehaviour
{
   // [HideInInspector]
    public float currentHP;

    public float maxHP;
    [HideInInspector]

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
