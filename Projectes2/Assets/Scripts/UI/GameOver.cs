using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public UnityEvent restart;

    private GameObject player;
    public GameObject mouse;


    public GameObject[] gameOver;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        foreach (GameObject item in gameOver)
        {
            item.SetActive(false);
        }
    }

    public void DeathScreen()
    {
        
        mouse.GetComponent<MousePointer>().ShootingMouseBool = false;
        Time.timeScale = 0.1f;
        foreach (GameObject item in gameOver)
        {
            item.SetActive(true);
        }
    }


    public void exitGame()
    {
        foreach (GameObject item in gameOver)
        {
            item.SetActive(true);
        }
        SceneManager.LoadScene(0);
    }

    public void restartGame()
    {
        restart.Invoke();
        foreach (GameObject item in gameOver)
        {
            item.SetActive(false);
        }
    }
}
