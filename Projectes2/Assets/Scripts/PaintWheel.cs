using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum PaintColors
{
    noPaint, red, cyan, blue, yellow, orange, pink, darkBlue, green
}


public class PaintWheel : MonoBehaviour
{
    public GameObject[] paintWheel;
    public bool shootable;
    public GameObject mause;

    private int rightButtonSelected = 15;
    private int leftButtonSelected = 15 ;

    [HideInInspector] public PaintColors rightPaint;
    [HideInInspector] public PaintColors leftPaint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PaintWheel"))
        {
            mause.GetComponent<MousePointer>().ShootingMouseBool = false;
            shootable = false;
            foreach(GameObject item in paintWheel)
                item.SetActive(true);
            Time.timeScale = 0.3f;
        }
        else if (Input.GetButtonUp("PaintWheel"))
        {
            mause.GetComponent<MousePointer>().ShootingMouseBool = true;
            shootable = true;
            foreach (GameObject item in paintWheel)
                item.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    //Function called from Button when clicked with left mouse button;
    public void LeftWheelClick(int button)
    {
        if(button != rightButtonSelected)
        {
            transform.GetChild(2).GetChild(0).GetComponent<Image>().color = GetColor(ChoiceColor(button));
            leftButtonSelected = button;

            leftPaint = ChoiceColor(button);
        }
        else
        {
            transform.GetChild(2).GetChild(0).GetComponent<Image>().color = GetColor(ChoiceColor(button));
            leftButtonSelected = button;

            leftPaint = ChoiceColor(button);
            rightPaint = ChoiceColor(15);
            transform.GetChild(2).GetChild(1).GetComponent<Image>().color = GetColor(ChoiceColor(15));
            rightButtonSelected = 15;
        }
    }



    //Function called from Button when clicked with right mouse button;
    public void RightWheelClick(int button)
    {

        if (button != leftButtonSelected)
        {
            transform.GetChild(2).GetChild(1).GetComponent<Image>().color = GetColor(ChoiceColor(button));
            rightButtonSelected = button;

            rightPaint = ChoiceColor(button);
        }
        else
        {
            transform.GetChild(2).GetChild(1).GetComponent<Image>().color = GetColor(ChoiceColor(button));
            rightButtonSelected = button;
            rightPaint = ChoiceColor(button);

            leftPaint = ChoiceColor(15);
            transform.GetChild(2).GetChild(0).GetComponent<Image>().color = GetColor(ChoiceColor(15));
            leftButtonSelected = 15;
        }
    }



    private PaintColors ChoiceColor(int button)
    {
        switch (button)
        {
            case 0:
                return PaintColors.orange;
            case 1:
                return PaintColors.blue;
            case 2:
                return PaintColors.pink;
            case 3:
                return PaintColors.green;
            default:
                return PaintColors.noPaint;
        }
    }

    private Color GetColor(PaintColors i)
    {
        switch (i)
        {
            case PaintColors.blue:
                return new Color(0, 0.686f, 0.85f);
            case PaintColors.orange:
                return new Color(1, 0.709f, 0.078f);
            case PaintColors.pink:
                return new Color(1, 0.68f, 0.8f);
            case PaintColors.green:
                return new Color(0, 0.69f, 0.24f);
            default:
                break;
        }

        return new Color(0.701f, 0.701f, 0.701f);
    }
}
