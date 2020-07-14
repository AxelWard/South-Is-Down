using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public static Vector3 GRAVITY;
    public static bool GROUNDED;
    public static Vector3 UP;

    private static string DIRECTION;

    public TextMeshPro directionText;

    public Transform cameraTransform;
    public float reorientationTime;
    public ModifierController modifiers;

    private Quaternion upwards;
    private float startTime;

    private int groundingObjects = 0;

    // Start is called before the first frame update
    void Start()
    { 
        GRAVITY = new Vector3(0f, -9.81f, 0f);
        DIRECTION = "DOWN";
        directionText.text = DIRECTION;
        upwards = Quaternion.Euler(0, 0, 0);
        ModifierController.ResetModifiers();
    }

    public void ResetGravity()
    {
        GRAVITY = new Vector3(0f, -9.81f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            string newDirection = GetGravityDirection();

            if(newDirection != DIRECTION)
            {
                GROUNDED = false;
                DIRECTION = newDirection;
                directionText.text = DIRECTION;
                startTime = Time.time;
                GetComponent<AudioSource>().Play();
            }

            if(modifiers != null)
            {
                modifiers.UpdateRandomModifier();
            }
        }

        Reorient();
        UpdateGrounded();
    }

    private string GetGravityDirection()
    {
        Vector3 cameraDirection = cameraTransform.forward;

        float x = Mathf.Abs(cameraDirection.x);
        float y = Mathf.Abs(cameraDirection.y);
        float z = Mathf.Abs(cameraDirection.z);

        if (x > y && x > z)
        {
            if (cameraDirection.x > 0)
            {
                GRAVITY = new Vector3(9.81f, 0f, 0f);
                upwards = Quaternion.Euler(0, 0, 90);
                return "NORTH";
            }
            else
            {
                GRAVITY = new Vector3(-9.81f, 0f, 0f);
                upwards = Quaternion.Euler(0, 0, -90);
                return "SOUTH";
            }
        }
        else if (y >= x && y >= z)
        {
            if (cameraDirection.y > 0)
            {
                GRAVITY = new Vector3(0f, 9.81f, 0f);
                upwards = Quaternion.Euler(-180, 0, 0);
                return "UP";
            }
            else
            {
                GRAVITY = new Vector3(0f, -9.81f, 0f);
                upwards = Quaternion.Euler(0, 0, 0);
                return "DOWN";
            }
        }
        else
        {
            if (cameraDirection.z > 0)
            {
                GRAVITY = new Vector3(0f, 0f, 9.81f);
                upwards = Quaternion.Euler(-90, 0, 0);
                return "WEST";
            }
            else
            {
                GRAVITY = new Vector3(0f, 0f, -9.81f);
                upwards = Quaternion.Euler(90, 0, 0);
                return "EAST";
            }
        }
    }

    private void Reorient() 
    {
        float progress = (Time.time - startTime) / reorientationTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, upwards, progress);
    }

    private void UpdateGrounded()
    {
        if(groundingObjects < 1)
        {
            GROUNDED = false;
        } 
        else
        {
            GROUNDED = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.name != name && other.tag != "NotFloor")
        {
            groundingObjects += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name != name && other.tag != "NotFloor") 
        {
            groundingObjects -= 1;
        }

    }
}
