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
    private AudioManager audioManager;

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
        audioManager = FindObjectOfType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (sceneChecker)
        {
            SceneSelector();
        }
        if (currentScene == "MainMenu" &&  menu)
        {
            if (audioManager != null)
                audioManager.Play("MenuSong");
            isPlaying = true;
        }
        else if (currentScene == "Nivell1" && !menu)
        {
            if (audioManager != null)
                audioManager.Stop("Cinematica");
            if (audioManager != null)
                audioManager.Play("InGameSong");
            isPlaying = true;

        }
        else if (currentScene == "Cinematic" && !menu)
        {
            if (audioManager != null)
                audioManager.Stop("MenuSong");
            if (audioManager != null)
                audioManager.Play("Cinematica");
            isPlaying = true;
        }
        else if (currentScene == "BossFight" && !menu)
        {
            if (audioManager != null)
                audioManager.Play("BossAmbient");
            if (audioManager != null)
               audioManager.Stop("InGameSong");

            isPlaying = true;
        }
    }

    private void SceneSelector()
    {
        currentScene = SceneManager.GetActiveScene().name.ToString();
    }
    public void NextScene()
    {
        SceneManager.LoadScene(1);
        menu = false;
    }
}