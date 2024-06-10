using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{

    [SerializeField] public PlayerController player_controller;
    [SerializeField] public ScoreController score_controller;
    private InterfaceScript interface_controller;

    private void Start()
    {
        player_controller = GameObject.FindFirstObjectByType<PlayerController>();
        score_controller = GameObject.FindFirstObjectByType<ScoreController>();
        interface_controller = GameObject.FindFirstObjectByType<InterfaceScript>();
    }

    public void EndGame() {
        Time.timeScale = 0;
        score_controller.StoreScore();
        interface_controller.ShowInterface();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        interface_controller.HideInterface();
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
