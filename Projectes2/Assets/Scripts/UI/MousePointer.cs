using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    public GameObject shotingMouse;
    public GameObject normalMouse;

    public bool ShootingMouseBool = true;

    private GameObject pointer;


    private void Start()
    {
        pointer = normalMouse;
        Cursor.visible = false;
    }

    void Update()
    {
        if (ShootingMouseBool == true)
        {
            pointer = shotingMouse;
            shotingMouse.SetActive(true);
            normalMouse.SetActive(false);


        }
        else
        {
            pointer = normalMouse;
            shotingMouse.SetActive(false);
            normalMouse.SetActive(true);


        }


        pointer.transform.position = Input.mousePosition;
    }
}
