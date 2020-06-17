using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum PaintColors
{
    red, cyan, blue, yellow, orange, pink, darkBlue, green
}


public class PaintWheel : MonoBehaviour
{
    public GameObject paintWheel;
    public bool shootable;
    public GameObject mouse;


    private int rightButtonSelected = 15;
    private int leftButtonSelected = 15 ;

    [HideInInspector] public PaintColors rightPaint;
    [HideInInspector] public PaintColors leftPaint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PaintWheel"))
        {
            mouse.GetComponent<MousePointer>().ShootingMouseBool = false;

            shootable = false;
            paintWheel.SetActive(true);
            Time.timeScale = 0.3f;
        }
        else if (Input.GetButtonUp("PaintWheel"))
        {
            mouse.GetComponent<MousePointer>().ShootingMouseBool = true;
            shootable = true;
            paintWheel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    //Function called from Button when clicked with left mouse button;
    public void LeftWheelClick(int button)
    {
       /* if (leftButtonSelected != rightButtonSelected)
        {*/
            if (leftButtonSelected != 15)
            {
                //resets color of the last button selected.
                transform.GetChild(0).GetChild(leftButtonSelected).GetComponent<Image>().color = new Color(1f, 1f, 1f);
            }
     //   }


        //changes to the right color.
        transform.GetChild(0).GetChild(button).GetComponent<Image>().color = new Color(1f, 0.3764f, 0.3764f);
        leftButtonSelected = button;

        leftPaint = ChoiceColor(button);
    }

    //leftbuttonselected = 0 i rightbuttonselected = 0
    //blau -> vermell


    //Function called from Button when clicked with right mouse button;
    public void RightWheelClick(int button)
    {
      /*  if(rightButtonSelected != leftButtonSelected)
        {*/
            if (rightButtonSelected != 15)
            {
                //resets color of the last button selected.
                transform.GetChild(0).GetChild(rightButtonSelected).GetComponent<Image>().color = new Color(1f, 1f, 1f);
            }
       // }

        //changes to the right color..
        transform.GetChild(0).GetChild(button).GetComponent<Image>().color = new Color(0.3764f, 0.4705f, 1);
        rightButtonSelected = button;

        rightPaint = ChoiceColor(button);
    }

    private PaintColors ChoiceColor(int button)
    {
        switch (button)
        {
            case 0:
                return PaintColors.red;
            case 1:
                return PaintColors.cyan;
            case 2:
                return PaintColors.yellow;
            case 3:
                return PaintColors.orange;
            case 4:
                return PaintColors.pink;
            default:
                return PaintColors.red;
        }
    }
}
