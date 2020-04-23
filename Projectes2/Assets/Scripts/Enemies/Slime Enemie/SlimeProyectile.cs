using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeProyectile : MonoBehaviour
{
    public float destroyTime = 5;
    public int DMG = 2;
    void Update()
    {
        Destroy(this.gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().currentHP -= 3;
        }
    }

}

