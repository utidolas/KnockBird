using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public GameObject text_gameOver;
    [SerializeField] public PlayerController player_controller;

    private void Start()
    {
        player_controller = GameObject.FindFirstObjectByType<PlayerController>();
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
