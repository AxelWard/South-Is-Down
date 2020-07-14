using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float REACH = 3f;

    public CharacterController controller;

    private Vector3 velocity;
    private float totalRotation;

    private void Start()
    {
        velocity = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        CheckRotation();
        CheckMovement();
        CheckGravity();
    }

    private void CheckRotation()
    {
        float rotation;

        if(Modifiers.invertMouseX) { 
            rotation = -Input.GetAxis("Mouse X") * PauseMenuManager.SENSITIVIY * Time.deltaTime;
        }
        else
        {
            rotation = Input.GetAxis("Mouse X") * PauseMenuManager.SENSITIVIY * Time.deltaTime;
        }

        totalRotation += rotation;
        transform.localRotation = Quaternion.Euler(0f, totalRotation, 0f);
    }

    private void CheckMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(x < 0 && !Modifiers.CanMoveLeft)
        {
            x = 0;
        }
        else if(x > 0 && !Modifiers.CanMoveRight)
        {
            x = 0;
        }

        if (z < 0 && !Modifiers.CanMoveBackward)
        {
            z = 0;
        }
        else if (z > 0 && !Modifiers.CanMoveForward)
        {
            z = 0;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        if (x != 0 || z != 0)
        {
            controller.Move(move * Modifiers.MoveSpeed * Time.deltaTime);
        }
    }

    private void CheckGravity()
    {
        if(!GravityController.GROUNDED)
        {
            Vector3 grav = GravityController.GRAVITY;
            velocity += grav * Time.deltaTime;
        } 
        else
        {
            velocity = new Vector3(0f, 0f, 0f);
        }

        controller.Move(velocity * Time.deltaTime);
    }
}