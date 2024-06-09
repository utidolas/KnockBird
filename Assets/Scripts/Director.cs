using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public GameObject text_gameOver;
    [SerializeField] public PlayerController player_controller;
    [SerializeField] public ScoreController score_controller;

    private void Start()
    {
        player_controller = GameObject.FindFirstObjectByType<PlayerController>();
        score_controller = GameObject.FindFirstObjectByType<ScoreController>();
    }

    public void EndGame() {
        Time.timeScale = 0;
        text_gameOver.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        text_gameOver.SetActive(false);
        player_controller.Restart();
        score_controller.ResetScore();
        DestroyObstacles();

    }

    public void DestroyObstacles()
    {
        ObstacleController[] obstacles = Object.FindObjectsOfType<ObstacleController>();
        foreach(ObstacleController obstacle in obstacles){
            obstacle.DestroySelf();
        }
    }
}
