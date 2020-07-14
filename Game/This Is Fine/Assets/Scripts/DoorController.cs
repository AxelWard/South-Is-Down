using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    bool isDoorOpen = false;

    public Animator rightDoor;
    public Animator leftDoor;
    public AudioSource doorSound;
    public List<ButtonController> buttons;

    // Update is called once per frame
    void Update()
    {
        if (CheckButtons()) 
        {
            rightDoor.SetBool("Open Door", true);
            leftDoor.SetBool("Open Door", true);
            if(!isDoorOpen)
            {
                doorSound.Stop();
                doorSound.Play();
            }
            isDoorOpen = true;
        }
        else
        {
            rightDoor.SetBool("Open Door", false);
            leftDoor.SetBool("Open Door", false);
            if (isDoorOpen)
            {
                doorSound.Stop();
                doorSound.Play();
            }
            isDoorOpen = false;
        }
    }

    private bool CheckButtons()
    {
        foreach(ButtonController button in buttons)
        {
            if(!button.isPressed)
            {
                return false;
            }
        }

        return true;
    }
}
