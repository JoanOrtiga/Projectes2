using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemieSystem : MonoBehaviour
{
    public int heath = 10;


    public Transform[] spawnPoints;
    public GameObject[] enemie;


    private void Start()
    {
        if (transform.childCount > 1)
        {
            spawnPoints[0] = this.gameObject.transform.GetChild(0);
            spawnPoints[1] = this.gameObject.transform.GetChild(1);
        }
        else
        {
            print("THis slime has no childern");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (enemie.Length == 0 && heath <= 0)
        {
            Destroy(this.gameObject);
        }
        else if (heath <= 0 && enemie.Length > 0)
        {
            Instantiate(enemie[0], spawnPoints[0].position, Quaternion.identity);
            Instantiate(enemie[0], spawnPoints[1].position, Quaternion.identity);
            Destroy(this.gameObject);
            
        }
       
    }
}
