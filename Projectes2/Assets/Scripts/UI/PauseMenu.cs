using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject mouseCanvas;

    private void Start()
    {
        pauseCanvas.SetActive(false);
    }
    public void pauseButton()
    {
        Time.timeScale = 0f;
        
        pauseCanvas.SetActive(true);
        mouseCanvas.GetComponent<MousePointer>().ShootingMouseBool = false;
    }

    public void resumeButton()
    {
        pauseCanvas.SetActive(false);
        mouseCanvas.GetComponent<MousePointer>().ShootingMouseBool = true;

        Time.timeScale = 1f;
    }

    public void exitButton()
    {
        Application.Quit();
    }

}
