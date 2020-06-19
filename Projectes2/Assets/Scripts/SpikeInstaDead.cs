using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeInstaDead : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerHealth>().currentHP = -5;
        }
    }
}
