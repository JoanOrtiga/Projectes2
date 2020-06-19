using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    private string currentScene;
    public bool isPlaying;
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
        if (currentScene == "MainMenu" &&  menu && !isPlaying)
        {
            if (audioManager != null)
                audioManager.Play("MenuSong");
            isPlaying = true;
        }
        else if (currentScene == "Nivell1" && !menu && !isPlaying)
        {
            if (audioManager != null)
                audioManager.Stop("Cinematica");
            if (audioManager != null)
                audioManager.Play("InGameSong");
            isPlaying = true;

        }
        else if (currentScene == "Cinematic" && !menu && !isPlaying)
        {
            if (audioManager != null)
                audioManager.Stop("MenuSong");
            if (audioManager != null)
                audioManager.Play("Cinematica");
            isPlaying = true;
        }
        else if (currentScene == "BossFight" && !menu && !isPlaying)
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
        isPlaying = false;
        menu = false;
    }
}