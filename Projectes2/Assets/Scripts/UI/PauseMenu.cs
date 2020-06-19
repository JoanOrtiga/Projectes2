using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseCanvas;

    private void Start()
    {
        PauseCanvas.SetActive(false);
    }
    public void pauseButton()
    {
        Time.timeScale = 0f;
        PauseCanvas.SetActive(true);
    }

    public void resumeButton()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void exitButton()
    {
        Application.Quit();
    }

}
