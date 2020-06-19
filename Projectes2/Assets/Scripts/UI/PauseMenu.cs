using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject mouseCanvas;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void pauseButton()
    {
        Time.timeScale = 0f;
        
        this.gameObject.SetActive(true);
        mouseCanvas.GetComponent<MousePointer>().ShootingMouseBool = false;
    }

    public void resumeButton()
    {
        this.gameObject.SetActive(false);
        mouseCanvas.GetComponent<MousePointer>().ShootingMouseBool = true;

        Time.timeScale = 1f;
    }

    public void exitButton()
    {
        Application.Quit();
    }

}
