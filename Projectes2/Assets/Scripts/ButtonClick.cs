using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonClick : MonoBehaviour , IPointerClickHandler
{
    public UnityEvent onLeft;
    public UnityEvent onRight;
    public UnityEvent onMiddle;

    public float AlphaThreshold = 0.1f;

    private void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            onLeft.Invoke();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            onRight.Invoke();
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
           // onMiddle.Invoke();
        }
    }
}
