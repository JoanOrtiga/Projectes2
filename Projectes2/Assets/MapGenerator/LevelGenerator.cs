using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<Vector2> roomSizesByType;
    public List<GameObject> roomTypes;

    public List<Vector2> ArrayOfRooms;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            GenerateLevel();
    }

    private void GenerateLevel()
    {

    }
}
