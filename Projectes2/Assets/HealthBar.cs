using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    private void Start()
    {
        GetComponent<Image>().fillAmount = player.GetComponent<PlayerHealth>().currentHP / player.GetComponent<PlayerHealth>().maxHP;
    }

    private void Update()
    {
        GetComponent<Image>().fillAmount = player.GetComponent<PlayerHealth>().currentHP / player.GetComponent<PlayerHealth>().maxHP;
    }
}
