using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPointManager : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletManager;

    public UnityEvent RespawnEnemies;
    Vector2 StartingPosition;

    public GameObject enemiesItem;

    private List<GameObject> enemiesCollection;
    private List<Vector2> enemiesCollectionPosition;

    private void Start()
    {
        for (int i = 0; i < enemiesItem.transform.childCount; i++)
        {
            enemiesCollection.Add(enemiesItem.transform.GetChild(i).gameObject);
            enemiesCollectionPosition.Add(enemiesItem.transform.GetChild(i).position);
        }
    }

    public void Restart()
    {
        player.transform.position = StartingPosition;
        player.GetComponent<PlayerHealth>().currentHP  = player.GetComponent<PlayerHealth>().maxHP;
        bulletManager.GetComponent<StainManager>().manaMana = bulletManager.GetComponent<StainManager>().manaMax;

        for (int i = 0; i < enemiesCollection.Count; i++)
        {
            enemiesCollection[i].transform.position = enemiesCollectionPosition[i];
            if (enemiesCollection[i].name == "meleEnemie")
            {
                enemiesCollection[i].transform.GetChild(0).GetComponent<MeleEnemie>().HP = 15;
            }
            else if(enemiesCollection[i].name == "shootingAlien")
            {
                enemiesCollection[i].GetComponent<StandardEnemie>().HP = 20;
            }
            else if(enemiesCollection[i].name == "FlyingEnemie")
            {
                enemiesCollection[i].transform.GetChild(0).GetComponent<FlyingEnemie>().HP = 15;
            }
        }
        
    }

    public void GetCheckPoint(Vector2 pos)
    {
        StartingPosition = pos;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            Restart();
        }
    }
}
