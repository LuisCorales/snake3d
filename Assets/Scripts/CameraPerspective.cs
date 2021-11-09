using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPerspective : MonoBehaviour
{
    public GameObject firstPerson;//Cameras
    public GameObject thirdPerson;

    //On start-up, always third person
    private void Start()
    {
        firstPerson.SetActive(false);
        thirdPerson.SetActive(true);
    }

    //Used to change the camera from 3rd to 1st person and viceversa
    public void ChangePerspective()
    {
        //Change both cameras to opposite of current state, activate one, deactivate the other
        firstPerson.SetActive(!firstPerson.activeSelf);
        thirdPerson.SetActive(!thirdPerson.activeSelf);
    }
}
