using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeInstaDead : MonoBehaviour
{
    GameObject manager;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("CheckManager");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("hola");
        if (collision.gameObject.CompareTag("Player"))
        {
            print("jajs");

            manager.GetComponent<CheckPointManager>().Restart();
        }
    }
}
