using System;
using UnityEngine;

public class AirCraftRotation : Steering {
    public float yDegreeRot;
    public float xDegreeRot;
    public float zDegreeRot;

    private Vector3 yRot;
    private Vector3 xRot;
    private Vector3 zRot;


    void Start () {
        yRot = new Vector3(0f, yDegreeRot, 0f);
        xRot = new Vector3(xDegreeRot, 0f, 0f);
        zRot = new Vector3(0f, 0f, zDegreeRot);
    }

	void FixedUpdate () {
        if (Input.GetKey(KeyCode.W))
        {
            RotateUp();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            RotateDown();
        }
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            TwistLeft();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            TwistRight();
        }
        
    }

    private void TwistLeft()
    {
        HandleRotation(zRot);
    }

    private void TwistRight()
    {
        HandleRotation(-zRot);
    }

    private void RotateRight()
    {
        HandleRotation(yRot);
    }

    private void RotateLeft()
    {
        HandleRotation(-yRot);
    }

    private void RotateDown()
    {
        HandleRotation(xRot);
    }

    private void RotateUp()
    {
        HandleRotation(-xRot);
    }
    private void HandleRotation(Vector3 direction)
    {
        transform.Rotate(direction * Time.deltaTime, Space.Self);
    }

}
