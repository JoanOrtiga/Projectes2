using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private SceneManagment manager;
    // Start is called before the first frame update
    public void Start()
    {
        manager = FindObjectOfType<SceneManagment>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            manager.isPlaying = false;
            SceneManager.LoadScene(3);
        }
    }
}
