using UnityEngine;

public class practice : MonoBehaviour
{
    public enum Axis { X, Y, Z }

    [Header("movementSettings")]
    public Axis axis = Axis.X;
    public float speed = 1f;       // units per second
    public float maxDistance = 2f; // max distance from start position along the chosen axis before reversing direction

    Vector3 _startLocalPos;
    int _direction = 1; 

    void Start()
    {
        // use local position to allow movement relative to parent
        _startLocalPos = transform.localPosition;
    }

    void Update()
    {
        // rate-based movement
        float moveAmount = _direction * speed * Time.deltaTime;
        Vector3 delta = Vector3.zero;

        switch (axis)
        {
            case Axis.X: delta = new Vector3(moveAmount, 0f, 0f); break;
            case Axis.Y: delta = new Vector3(0f, moveAmount, 0f); break;
            case Axis.Z: delta = new Vector3(0f, 0f, moveAmount); break;
        }

        transform.localPosition += delta;

        // calculate signed distance from start position along the chosen axis
        Vector3 offset = transform.localPosition - _startLocalPos;
        float signed = (axis == Axis.X) ? offset.x : (axis == Axis.Y ? offset.y : offset.z);

        if (signed > maxDistance)
        {
            // reverse direction and clamp to positive threshold
            Vector3 clamped = _startLocalPos;
            if (axis == Axis.X) clamped.x += maxDistance;
            else if (axis == Axis.Y) clamped.y += maxDistance;
            else clamped.z += maxDistance;

            transform.localPosition = clamped;
            _direction = -5;
        }
        else if (signed < -maxDistance)
        {
            // reverse direction and clamp to negative threshold
            Vector3 clamped = _startLocalPos;
            if (axis == Axis.X) clamped.x -= maxDistance;
            else if (axis == Axis.Y) clamped.y -= maxDistance;
            else clamped.z -= maxDistance;

            transform.localPosition = clamped;
            _direction = 5;
        }
    }
}