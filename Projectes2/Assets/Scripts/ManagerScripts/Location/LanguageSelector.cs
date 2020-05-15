using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSelector : MonoBehaviour
{
    public GameObject menuIdioma;
    public GameObject botonSonido;
    public GameObject botonPlay;
    public GameObject botonIdioma;
    public GameObject botonExit;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void LanguageSelection()
    {
        menuIdioma.SetActive(true);
        botonSonido.SetActive(false);
        botonPlay.SetActive(false);
        botonIdioma.SetActive(false);
        botonExit.SetActive(false);

    }
    public void Done()
    {
        menuIdioma.SetActive(false);
        botonPlay.SetActive(true);
        botonSonido.SetActive(true);
        botonIdioma.SetActive(true);
        botonExit.SetActive(false);

    }
}