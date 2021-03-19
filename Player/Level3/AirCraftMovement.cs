using UnityEngine;

public class AirCraftMovement : Steering {
    private float xDir;
    private float zDir;

    public float movementSpeed;

    private void Start()
    {
        xDir = 0f;
        zDir = 0f;
    }

    private void FixedUpdate () {
        StopAllMovement();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            zDir = movementSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            zDir = -movementSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xDir = -movementSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xDir = movementSpeed;
        }
        Move(xDir, zDir);
    }

    private void Move(float x, float z)
    {
        Vector3 dir = new Vector3(x, 0f, z);
        transform.position += transform.TransformDirection(dir) * Time.deltaTime;
    }
    private void StopAllMovement()
    {
        xDir = 0f;
        zDir = 0f;
    }
}
