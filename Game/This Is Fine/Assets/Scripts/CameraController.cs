using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float clamp;

    public float totalRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        float rotation;
        if(Modifiers.invertMouseY)
        {
            rotation = Input.GetAxis("Mouse Y") * PauseMenuManager.SENSITIVIY * Time.deltaTime;
        }
        else
        {
            rotation = -Input.GetAxis("Mouse Y") * PauseMenuManager.SENSITIVIY * Time.deltaTime;
        }

        totalRotation += rotation;
        totalRotation = Mathf.Clamp(totalRotation, -clamp, clamp);

        transform.localRotation = Quaternion.Euler(totalRotation, 0f, 0f);
    }
}
