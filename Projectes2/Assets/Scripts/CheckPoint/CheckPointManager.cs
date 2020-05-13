using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPointManager : MonoBehaviour
{
    public GameObject player;

    public UnityEvent RespawnEnemies;
    Vector2 StartingPosition;

    public void Restart()
    {
        player.transform.position = StartingPosition;
        RespawnEnemies.Invoke();
    }

    public void GetCheckPoint(Vector2 pos)
    {
        StartingPosition = pos;
    }
}
