using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    private bool gameOver;
    [SerializeField] GameObject snake;
    [SerializeField] TextMeshProUGUI points;
    [SerializeField] GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;//Unpause game
    }

    // Update is called once per frame
    void Update()
    {
        HandleScore();
        HandleGameOver();
    }

    private void HandleScore()
    {
        points.text = "Points: " + snake.GetComponent<SnakeEater>().GetEatenFruits();
    }

    private void HandleGameOver()
    {
        gameOver = snake.GetComponent<SnakeEater>().IsDead();
        if (gameOver)//End the game
        {
            Time.timeScale = 0;//Pause game
            UI.GetComponent<UIController>().ToggleMenu(true); //Show menu to quit or restart game
        }
    }
}
