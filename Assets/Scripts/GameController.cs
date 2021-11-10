using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    private bool gameOver = false;
    [SerializeField]
    private GameObject snake;
    [SerializeField]
    private TextMeshProUGUI points;
    [SerializeField]
    private GameObject overMessage;
    [SerializeField]
    private GameObject restartButton;
    [SerializeField]
    private GameObject exitButton;
    [SerializeField]
    private GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateScore();
        this.UpdateGameOver();
    }

    private void UpdateScore()
    {
        points.text = "Points: " + snake.GetComponent<SnakeEater>().GetEatenFruits();
    }

    private void UpdateGameOver()
    {
        this.gameOver = snake.GetComponent<SnakeEater>().IsDead();
        if (gameOver)//End the game
        {
            Time.timeScale = 0;//Pause game
            overMessage.SetActive(true);//Enable game over message and options
            restartButton.SetActive(true);
            exitButton.SetActive(true);
            this.RestartOrExit();//Check what to do next, restar or exit game
        }
    }

    private void RestartOrExit()
    {
        if (UI.GetComponent<UIController>().GetRestartClicked())//Reload scene if restart is clicked
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
        }else if (UI.GetComponent<UIController>().GetExitClicked())
        {
            Application.Quit();
        }
    }

}
