using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PaintWheel : MonoBehaviour
{
    public GameObject paintWheel;

    private int rightButtonSelected = 0;
    private int leftButtonSelected = 0; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PaintWheel"))
        {
            paintWheel.SetActive(true);
            Time.timeScale = 0.3f;
        }
        else if (Input.GetButtonUp("PaintWheel"))
        {
            paintWheel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void LeftWheelClick(int button)
    {
        transform.GetChild(0).GetChild(leftButtonSelected).GetComponent<Image>().color = new Color(1f, 1f, 1f);

        transform.GetChild(0).GetChild(button).GetComponent<Image>().color = new Color(1f, 0.3764f, 0.3764f);
        leftButtonSelected = button;
    }

    public void RightWheelClick(int button)
    {
        transform.GetChild(0).GetChild(rightButtonSelected).GetComponent<Image>().color = new Color(1f, 1f, 1f);

        transform.GetChild(0).GetChild(button).GetComponent<Image>().color = new Color(0.3764f, 0.4705f, 1);
        rightButtonSelected = button;
    }
}
