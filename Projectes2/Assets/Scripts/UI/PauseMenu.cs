using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject mouseCanvas;
    public PaintWheel paintWheel;

    public bool gamePaused;

    private void Start()
    {
        pauseCanvas.SetActive(false);
    }
    public void pauseButton()
    {
        paintWheel.shootable = false;
        Time.timeScale = 0f;
        gamePaused = true;
        pauseCanvas.SetActive(true);
        mouseCanvas.GetComponent<MousePointer>().ShootingMouseBool = false;
    }

    public void resumeButton()
    {
        pauseCanvas.SetActive(false);
        mouseCanvas.GetComponent<MousePointer>().ShootingMouseBool = true;

        Time.timeScale = 1f;
        gamePaused = false;
        paintWheel.shootable = true;
    }

    public void exitButton()
    {
        SceneManager.LoadScene(0);
    }

}
