using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject SoundMenu;
    private bool SMisActive;
    // Start is called before the first frame update
    void Start()
    {
        SMisActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void exit()
    {
        Application.Quit();
    }
    public void start()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Sound()
    {
        if (SMisActive)
        {
            SoundMenu.SetActive(false);
            SMisActive = false;
        }
        else if (SMisActive==false)
        {
            SoundMenu.SetActive(true);
            SMisActive = true;
        }
    }
}
