using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    CameraDeathZone deathZoneGeneral;
    private void Start()
    {
        deathZoneGeneral = GetComponent<CameraDeathZone>();
    }

    public void NewRoom(Vector2 pos1, Vector2 pos2)
    {
        deathZoneGeneral.limitPos1 = pos1;
        deathZoneGeneral.limitPos2 = pos2;

        deathZoneGeneral.clamped = true;
    }
}
