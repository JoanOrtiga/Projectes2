using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public List<GameObject> enemiesToSpawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject item in enemiesToSpawn)
            {
                item.SetActive(true);
            }

            gameObject.SetActive(false);
        }
    }
}
