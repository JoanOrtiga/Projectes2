using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public GameObject BulletManager;
    private void Start()
    {
        GetComponent<Image>().fillAmount = BulletManager.GetComponent<StainManager>().manaMana / BulletManager.GetComponent<StainManager>().manaMax;
    }

    private void Update()
    {
        GetComponent<Image>().fillAmount = BulletManager.GetComponent<StainManager>().manaMana / BulletManager.GetComponent<StainManager>().manaMax;
    }
}
