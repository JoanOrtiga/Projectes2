using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{
    // Start is called before the first frame update
   public void nextScene()
    {
        SceneManager.LoadScene(2);
    }


    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
