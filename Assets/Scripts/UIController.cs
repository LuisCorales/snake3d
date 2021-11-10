using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject cameras;

    [SerializeField]
    private TextMeshProUGUI buttonText;

    private bool restartClicked = false;
    private bool exitClicked = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCamera()//Change camera perspective
    {
        cameras.GetComponent<CameraPerspective>().ChangePerspective();
        this.ChangeButtonText();
    }

    private void ChangeButtonText()//Change button text when it is clicked
    {
        if (buttonText.text.Equals("First Person"))
        {
            buttonText.SetText("Third Person");
        }
        else
        {
            buttonText.SetText("First Person");
        }
    }

    public void RestartClick()
    {
        this.restartClicked = true;
    }

    public void ExitClick()
    {
        this.exitClicked = true;
    }

    public bool GetRestartClicked()
    {
        return this.restartClicked;
    }

    public bool GetExitClicked()
    {
        return this.exitClicked;
    }

}
