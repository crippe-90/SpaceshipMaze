using UnityEngine;

public class Level1Steering : Steering {
    
    private Vector3 dir;
    private Vector3 newPosition;
    private Vector3 rotationVector;

    public float forward;
    public float backward;
    public float rotation;

    private void Start()
    {
        rotationVector = new Vector3(0f, rotation, 0f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            GoForward();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            GoBackward();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateRight();
        }
    }

    private void GoForward()
    {
        newPosition = new Vector3(0, 0, forward);
        transform.position += transform.TransformDirection(newPosition) * Time.deltaTime;
    }

    private void GoBackward()
    {            
            newPosition = new Vector3(0, 0, backward);
            transform.position += transform.TransformDirection(newPosition) * Time.deltaTime;
    }

    private void RotateLeft()
    {
        transform.Rotate(-rotationVector * Time.deltaTime, Space.Self);
    }

    private void RotateRight()
    {
        transform.Rotate(rotationVector * Time.deltaTime, Space.Self);
    }

}
