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

    private int rightButtonSelected = 15;
    private int leftButtonSelected = 15 ;

    [HideInInspector] public PaintColors rightPaint;
    [HideInInspector] public PaintColors leftPaint;

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

    //Function called from Button when clicked with left mouse button;
    public void LeftWheelClick(int button)
    {
        if (leftButtonSelected != rightButtonSelected)
        {
            if (leftButtonSelected != 15)
            {
                //resets color of the last button selected.
                transform.GetChild(0).GetChild(leftButtonSelected).GetComponent<Image>().color = new Color(1f, 1f, 1f);
            }
        }
        

        //changes to the right color.
        transform.GetChild(0).GetChild(button).GetComponent<Image>().color = new Color(1f, 0.3764f, 0.3764f);
        leftButtonSelected = button;

        leftPaint = ChoiceColor(button);
    }

    //Function called from Button when clicked with right mouse button;
    public void RightWheelClick(int button)
    {
        if(rightButtonSelected != leftButtonSelected)
        {
            if (rightButtonSelected != 15)
            {
                //resets color of the last button selected.
                transform.GetChild(0).GetChild(rightButtonSelected).GetComponent<Image>().color = new Color(1f, 1f, 1f);
            }

        }

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
                break;
            case 1:
                return PaintColors.cyan;
                break;
            case 2:
                return PaintColors.blue;
                break;
            case 3:
                return PaintColors.yellow;
                break;
            case 4:
                return PaintColors.orange;
                break;
            case 5:
                return PaintColors.pink;
                break;
            case 6:
                return PaintColors.darkBlue;
                break;
            case 7:
                return PaintColors.green;
                break;

            default:
                return PaintColors.red;
                break;

        }
    }
}
