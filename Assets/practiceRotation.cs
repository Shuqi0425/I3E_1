using UnityEngine;

public class practiceRotation : MonoBehaviour
{
    public enum Axis { X, Y, Z }

    [Header("rotationSettings")]
    public bool enableRotate = true;
    public Axis rotateAxis = Axis.Y;
    public float angularSpeed = 90f; // degrees per second
    public float maxAngle = 45f;     // max angle relative to start (degrees+-)

    Vector3 startLocalEuler;
    float currentAngle = 0f; // accumulated angle offset from start
    int rotateDirection = 1;

    
    void Start()
    {
        //record initial local angles as reference
        startLocalEuler = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (!enableRotate) return;

        // angle increment for this frame
        float delta = rotateDirection * angularSpeed * Time.deltaTime;
        currentAngle += delta;

        // reverse when reaching limits
        if (currentAngle > maxAngle)
        {
            currentAngle = maxAngle;
            rotateDirection = -1;
        }
        else if (currentAngle < -maxAngle)
        {
            currentAngle = -maxAngle;
            rotateDirection = 1;
        }

        // build offset vector based on selected axis
        Vector3 offset = Vector3.zero;
        if (rotateAxis == Axis.X) offset = new Vector3(currentAngle, 0f, 0f);
        else if (rotateAxis == Axis.Y) offset = new Vector3(0f, currentAngle, 0f);
        else offset = new Vector3(0f, 0f, currentAngle);

        transform.localEulerAngles = startLocalEuler + offset;
    }
}
