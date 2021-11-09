using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject snake;//Reference to the starting snake bit
    private Vector3 offset;//Distance the camera should move to keep up with the snek

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - snake.transform.position;//Current cam position minus snake position
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = snake.transform.position + offset;//Update the cameras position
    }
}
