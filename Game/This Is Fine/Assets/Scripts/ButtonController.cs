using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Material pressed;
    public Material unpressed;
    public Light buttonLight;

    public bool isPressed;

    private MeshRenderer buttonRenderer;

    private int collisionCount;

    // Start is called before the first frame update
    void Start()
    {
        buttonRenderer = GetComponent<MeshRenderer>();
        collisionCount = 0;
    }

    private void Deactivate()
    {
        buttonRenderer.sharedMaterial = unpressed;
        isPressed = false;
        buttonLight.color = new Color(194f / 255f, 46f / 255f, 83f / 255f);
    }

    private void Activate()
    {
        buttonRenderer.sharedMaterial = pressed;
        isPressed = true;
        buttonLight.color = new Color(90f/255f, 166f/255f, 83f/255f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        collisionCount += 1;
        Activate();
    }

    public void OnCollisionExit(Collision collision)
    {
        collisionCount -= 1;

        if(collisionCount < 1)
        {
            Deactivate();
        }
    }
}
