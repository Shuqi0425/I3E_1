using UnityEngine;

public class practice : MonoBehaviour
{
    public enum Axis { X, Y, Z }

    [Header("移动设置")]
    public Axis axis = Axis.X;
    public float speed = 1f;       // 单位：单位/秒
    public float maxDistance = 2f; // 相对于起始位置的最大距离

    Vector3 _startLocalPos;
    int _direction = 1; // 1 表示正方向，-1 表示负方向

    void Start()
    {
        // 统一使用 localPosition 作为参考（避免父对象变换影响）
        _startLocalPos = transform.localPosition;
    }

    void Update()
    {
        // 每帧移动量（帧率无关）
        float moveAmount = _direction * speed * Time.deltaTime;
        Vector3 delta = Vector3.zero;

        switch (axis)
        {
            case Axis.X: delta = new Vector3(moveAmount, 0f, 0f); break;
            case Axis.Y: delta = new Vector3(0f, moveAmount, 0f); break;
            case Axis.Z: delta = new Vector3(0f, 0f, moveAmount); break;
        }

        transform.localPosition += delta;

        // 计算相对于起始位置的偏移量并判断是否超过阈值
        Vector3 offset = transform.localPosition - _startLocalPos;
        float signed = (axis == Axis.X) ? offset.x : (axis == Axis.Y ? offset.y : offset.z);

        if (signed > maxDistance)
        {
            // 夹紧到正阈值并反向
            Vector3 clamped = _startLocalPos;
            if (axis == Axis.X) clamped.x += maxDistance;
            else if (axis == Axis.Y) clamped.y += maxDistance;
            else clamped.z += maxDistance;

            transform.localPosition = clamped;
            _direction = -1;
        }
        else if (signed < -maxDistance)
        {
            // 夹紧到负阈值并反向
            Vector3 clamped = _startLocalPos;
            if (axis == Axis.X) clamped.x -= maxDistance;
            else if (axis == Axis.Y) clamped.y -= maxDistance;
            else clamped.z -= maxDistance;

            transform.localPosition = clamped;
            _direction = 1;
        }
    }
}