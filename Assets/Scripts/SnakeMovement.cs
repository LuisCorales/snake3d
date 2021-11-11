using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] GameObject body;

    [SerializeField] float speed = 3f;

    string currentInput;
    string currentDir;
    
    Transform headPosition;

    // Directions
    Vector3 leftDir;
    Vector3 rightDir;
    Vector3 upDir;
    Vector3 downDir;

    Vector3 newDir;

    Vector3 newRotation;

    bool hasToRotate;

    void Start()
    {
        //Reset all variables when starting
        currentInput = "up";
        currentDir = "up";
        newDir = transform.position;     
        hasToRotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        leftDir = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        rightDir = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        upDir = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        downDir = new Vector3(transform.position.x , transform.position.y, transform.position.z - 1);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentInput = "up";
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentInput = "down";
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentInput = "left";
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentInput = "right";
        }

        switch (currentInput.ToLower())
        {
            case "up"://Move to this direction only if the current one isnt the opposite
                if (!currentDir.Equals("down"))
                {
                    newDir = upDir;                 
                    switch (currentDir.ToLower())
                    {
                        case "left":
                            newRotation = new Vector3(0, 90, 0); //Rotate 90 to north
                            hasToRotate = true;
                            break;

                        case "right":
                            newRotation = new Vector3(0, -90, 0); //Rotate -90 to north
                            hasToRotate = true;
                            break;
                    }
                    //currentDir = currentInput;
                }
                else
                {
                    newDir = downDir;
                }
            break;

            case "down":
                if (!currentDir.Equals("up"))
                {
                    newDir = downDir;
                    switch (currentDir.ToLower())
                    {
                        case "left":
                            newRotation = new Vector3(0, -90, 0); //Rotate 90 to south
                            hasToRotate = true;
                            break;

                        case "right":
                            newRotation = new Vector3(0, 90, 0); //Rotate -90 to south
                            hasToRotate = true;
                            break;
                    }
                    //currentDir = currentInput;
                }
                else
                {
                    newDir = upDir;
                }
                break;

            case "left":
                if (!currentDir.Equals("right"))
                {
                    newDir = leftDir;
                    switch (currentDir.ToLower())
                    {
                        case "up":
                            newRotation = new Vector3(0, -90, 0); //Rotate 90 to west
                            hasToRotate = true;
                            break;

                        case "down":
                            newRotation = new Vector3(0, 90, 0); //Rotate -90 to west
                            hasToRotate = true;
                            break;
                    }
                    //currentDir = currentInput;
                }
                else
                {
                    newDir = rightDir;
                }
                break;

            case "right":
                if (!currentDir.Equals("left"))
                {
                    newDir = rightDir;                   
                    switch (currentDir.ToLower())
                    {
                        case "up":
                            newRotation = new Vector3(0, 90, 0); //Rotate 90 to east
                            hasToRotate = true;
                            break;

                        case "down":
                            newRotation = new Vector3(0, -90, 0); //Rotate -90 to east
                            hasToRotate = true;
                            break;
                    }
                    //currentDir = currentInput;
                }
                else
                {
                    newDir = leftDir;
                }
                break;

            default:
            break;
        }

        if (hasToRotate && !currentDir.Equals(currentInput))
        {
            hasToRotate = false;
            transform.Rotate(newRotation, Space.World);
            currentDir = currentInput;
        }

        transform.position = Vector3.MoveTowards(transform.position, newDir, Time.deltaTime * speed);

        /*if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //If the new direction is the same as the one
            //detected by the arrow keys, then don't change the old one
            oldInput = currentInput == "up" ? oldInput : currentInput; 
            currentInput = "up";
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            oldInput = currentInput == "down" ? oldInput : currentInput;
            currentInput = "down";
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            oldInput = currentInput == "left" ? oldInput : currentInput;
            currentInput = "left";
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            oldInput = currentInput == "right" ? oldInput : currentInput;
            currentInput = "right";
        }

        switch(currentInput.ToLower())
        {
            case "up":
                if(oldInput != "up" || oldInput != "down")
                    hasToRotate = true;

                switch (oldInput.ToLower())
                {
                    case "left":
                        newRotation = new Vector3(0, 90, 0); //Rotate 90 to north
                        currentDir = upDir;
                    break;

                    case "right":
                        newRotation = new Vector3(0, -90, 0); //Rotate -90 to north
                        currentDir = upDir;
                    break;

                    case "down":
                        currentDir = downDir;
                    break;
                    
                    default:
                        currentDir = upDir;
                    break;
                }
            break;

            case "down":
                if(oldInput != "up" || oldInput != "down")
                    hasToRotate = true;

                switch (oldInput.ToLower())
                {
                    case "left":
                        newRotation = new Vector3(0, 90, 0); //Rotate 90 to south
                        currentDir = downDir;
                    break;

                    case "right":
                        newRotation = new Vector3(0, -90, 0); //Rotate -90 to south
                        currentDir = downDir;
                    break;

                    case "up":
                        currentDir = upDir;
                    break;
                    
                    default:
                        currentDir = downDir;
                    break;
                }
            break;

            case "left":
                if(oldInput != "left" || oldInput != "right")
                    hasToRotate = true;

                switch (oldInput.ToLower())
                {
                    case "up":
                        newRotation = new Vector3(0, 90, 0); //Rotate 90 to west
                        currentDir = leftDir;
                    break;

                    case "down":
                        newRotation = new Vector3(0, -90, 0); //Rotate -90 to west
                        currentDir = leftDir;
                    break;

                    case "right":
                        currentDir = rightDir;
                    break;
                    
                    default:
                        currentDir = leftDir;
                    break;
                }
            break;

            case "right":
                if(oldInput != "left" || oldInput != "right")
                    hasToRotate = true;

                switch (oldInput.ToLower())
                {
                    case "up":
                        newRotation = new Vector3(0, 90, 0); //Rotate 90 to east
                        currentDir = rightDir;
                    break;

                    case "down":
                        newRotation = new Vector3(0, -90, 0); //Rotate -90 to east
                        currentDir = rightDir;
                    break;

                    case "left":
                        currentDir = leftDir;
                    break;
                    
                    default:
                        currentDir = rightDir;
                    break;
                }
            break;

            default:
            break;
        }

        if (hasToRotate)
        {
            hasToRotate = false;
            transform.Rotate(newRotation, Space.World);
        }

        transform.position = Vector3.MoveTowards(transform.position, currentDir, Time.deltaTime * speed);

        */
    }

}
