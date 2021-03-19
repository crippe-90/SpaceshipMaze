using UnityEngine;

public class RotatingObject : MonoBehaviour {
    public Transform thingToRotate;

    public Vector3 rotationPerSec;

    private void FixedUpdate()
    {
        thingToRotate.Rotate(rotationPerSec* Time.deltaTime, Space.Self);
    }
}
