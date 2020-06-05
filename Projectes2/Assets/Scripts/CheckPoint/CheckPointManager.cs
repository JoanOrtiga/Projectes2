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


    public void Restart()
    {
        print(StartingPosition);
        player.transform.position = StartingPosition;
        player.GetComponent<PlayerHealth>().  = player.GetComponent<PlayerHealth>().maxHP;
        bulletManager.GetComponent<StainManager>().manaMana = bulletManager.GetComponent<StainManager>().manaMax;

        RespawnEnemies.Invoke();
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
