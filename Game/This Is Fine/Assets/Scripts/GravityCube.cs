using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCube : MonoBehaviour
{
    public bool held = false;

    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (held)
        {
            body.velocity = new Vector3(0, 0, 0);
            body.angularVelocity = new Vector3(0, 0, 0);
        } 
        else
        {
            body.AddForce(GravityController.GRAVITY);
        }
    }

    private void OnMouseDown()
    {
        Transform cameraTrans = FindObjectOfType<Camera>().transform;

        if (GetDistanceTo(cameraTrans.position) < PlayerController.REACH)
        {
            held = true;
            transform.SetParent(cameraTrans);
        }
    }

    private void OnMouseUp()
    {
        transform.SetParent(null);
        held = false;
    }

    private float GetDistanceTo(Vector3 check)
    {
        float distance = (transform.position - check).magnitude;

        return distance;
    }
}
