using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObject : MonoBehaviour
{
    public bool held = false;

    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(held)
        {
            body.velocity = new Vector3(0, 0, 0);
            body.angularVelocity = new Vector3(0, 0, 0);
        }
    }

    private void OnMouseDown()
    {
        Transform cameraTrans = FindObjectOfType<Camera>().transform;

        if(GetDistanceTo(cameraTrans.position) < PlayerController.REACH)
        {
            held = true;
            transform.SetParent(cameraTrans);
            body.useGravity = false;
        }
    }

    private void OnMouseUp()
    {
        transform.SetParent(null);
        held = false;
        body.useGravity = true;
    }

    private float GetDistanceTo(Vector3 check)
    {
        float distance = (transform.position - check).magnitude;

        return distance;
    }
}
