using UnityEngine;

public class newComponent : MonoBehaviour
{
    Vector3 valueToMove = new Vector3(0.005f, 0, 0.01f);

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += valueToMove;
        transform.localScale += valueToMove;
        //print(transform.localPosition.x);
        //print(transform.localposition.y);
        //print(transform.localposition.z);
    }
}
