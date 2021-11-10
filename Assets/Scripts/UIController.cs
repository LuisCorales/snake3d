using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject cameras;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] GameObject menu;

    void Start() 
    {
        ToggleMenu(false);
        Debug.Log("aaa");
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

    public void ToggleMenu(bool turnOn)
    {
        menu.SetActive(turnOn);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
