using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    private string currentScene;
    private bool isPlaying;
    [HideInInspector]
    public bool sceneChecker;
    private bool menu;
    
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }
    public void Start()
    {
        sceneChecker = true;
        isPlaying = false;
        menu = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneChecker)
        {
            SceneSelector();
        }
        if (currentScene == "MainMenu" && !isPlaying && menu)
        {
            FindObjectOfType<AudioManager>().Play("MenuSong");
            isPlaying = true;
        }
        else if (currentScene == "Level1" && !isPlaying && !menu)
        {
            FindObjectOfType<AudioManager>().Play("InGameSong");
            isPlaying = true;

        }
        Debug.Log(SceneManager.GetActiveScene().name   +   currentScene    +   sceneChecker);
    }

    private void SceneSelector()
    {
        currentScene = SceneManager.GetActiveScene().name.ToString();
        print(currentScene);

    }
    public void NextScene()
    {
        FindObjectOfType<AudioManager>().Stop("MenuSong");
        SceneManager.LoadScene("Level1");
        menu = false;
        isPlaying = false;
    }
}