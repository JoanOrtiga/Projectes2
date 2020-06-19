using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    public void exit()
    {
        if (!Application.isEditor)
            System.Diagnostics.Process.GetCurrentProcess().Kill();

        Application.Quit();
    }
}
