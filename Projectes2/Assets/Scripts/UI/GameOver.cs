using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject player;
    public GameObject mouse;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       // this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerHealth>().currentHP >= 0)
        {
            mouse.GetComponent<MousePointer>().ShootingMouseBool = false;
            this.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void restartGame()
    {

    }
}
