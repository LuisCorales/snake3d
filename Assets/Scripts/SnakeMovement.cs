using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] GameObject body;

    [SerializeField] float speed = 3f;

    string currentDirection;
    string oldDirection;

    Transform headPosition;

    void Awake()
    {
        currentDirection = "up";
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        oldDirection = currentDirection;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentDirection = "up";
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentDirection = "down";
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentDirection = "left";
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentDirection = "right";
        }

        switch(currentDirection.ToLower())
        {
            case "up":
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Time.deltaTime * speed);
            break;

            case "down":
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Time.deltaTime * speed);
            break;

            case "left":
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Time.deltaTime * speed);
            break;

            case "right":
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Time.deltaTime * speed);
            break;

            default:
                
            break;
        }
    }

}
