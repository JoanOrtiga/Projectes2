using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSonido : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menuSonido;
    public GameObject botonSonido;
    public GameObject botonPlay;
    public GameObject botonIdioma;
    public GameObject botonExit;

    private bool isMuted = false;

    void Start()
    {
    }

    // Update is called once per frame
    public void SoundMenu()
    {
        menuSonido.SetActive(true);
        botonSonido.SetActive(false);
        botonPlay.SetActive(false);
        botonIdioma.SetActive(false);
        botonExit.SetActive(false);
    }

    public void Mute()
    {

        if (isMuted)
        {
            isMuted = false;
            FindObjectOfType<AudioManager>().Resume("MenuSong");

        }
        else
        {
            isMuted = true;
            FindObjectOfType<AudioManager>().Mute("MenuSong");

        }
    }
    public void Done()
    {
        menuSonido.SetActive(false);
        botonPlay.SetActive(true);
        botonSonido.SetActive(true);
        botonIdioma.SetActive(true);
        botonExit.SetActive(true);

    }
}
