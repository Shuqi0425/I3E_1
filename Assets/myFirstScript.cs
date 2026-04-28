using UnityEngine;

public class myFirstScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("hello world");
    }

    // Update is called once per frame
    void Update()
    {
        print(transform.position);
        //print(transform.localrotation);
    }
}
