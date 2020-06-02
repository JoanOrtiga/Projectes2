using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemieDMG : MonoBehaviour
{
    public GameObject thisEnemie;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().currentHP -= thisEnemie.GetComponent<MeleEnemie>().DMG;
        }
    }
}
