using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{
    private SceneManagment manager;
    // Start is called before the first frame update
    public void Start()
    {
        manager = FindObjectOfType<SceneManagment>();

    }
    public void nextScene()
    {
        manager.isPlaying = false;
        SceneManager.LoadScene(2);
    }


    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
