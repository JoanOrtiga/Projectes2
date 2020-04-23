using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;

    [HideInInspector] public Vector2 limitPos1;
    [HideInInspector] public Vector2 limitPos2;

    [Range(0, 1)] public float smoothFactor = 0.1f;

    public bool clamped = false;

    float cameraWidth, cameraHeight;
    // Start is called before the first frame update
    void Start()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 newPos = Target.position;
        newPos.z = -10;

        // print(newPos + "   " + limitPos1.x + Camera.main.orthographicSize * 1.5 + "   " + limitPos2.x + Camera.main.orthographicSize * 1.5);

        if (clamped)
        {
            newPos = new Vector3(Mathf.Clamp(newPos.x, limitPos1.x + cameraWidth, limitPos2.x - cameraWidth), Mathf.Clamp(newPos.y, limitPos1.y + cameraHeight, limitPos2.y - cameraHeight), -10);
        }
       

        print(newPos);
        // transform.position = newPos;

        transform.position = Vector3.Lerp(transform.position, newPos, smoothFactor);
    }
}
