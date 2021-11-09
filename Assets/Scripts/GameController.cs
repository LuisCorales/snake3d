using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    private bool gameOver = false;
    [SerializeField]
    private GameObject snake;
    [SerializeField]
    private TextMeshProUGUI points;

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
        points.text = points.text + snake.GetComponent<SnakeEater>().GetEatenFruits();
    }

    private void UpdateGameOver()
    {
        this.gameOver = snake.GetComponent<SnakeEater>().IsDead();
    }

}
