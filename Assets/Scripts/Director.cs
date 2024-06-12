using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{

    private PlayerController player_controller;
    private ScoreController score_controller;
    private InterfaceScript interface_controller;
    private DifficultController difficult_controller;
    private BotScript bot_controller;

    private void Start()
    {
        player_controller = GameObject.FindFirstObjectByType<PlayerController>();
        score_controller = GameObject.FindFirstObjectByType<ScoreController>();
        interface_controller = GameObject.FindFirstObjectByType<InterfaceScript>();
        difficult_controller = GameObject.FindFirstObjectByType<DifficultController>();
        bot_controller = GameObject.FindFirstObjectByType<BotScript>();
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
        bot_controller.Restart();
        score_controller.ResetScore();
        DestroyObstacles();
        difficult_controller.Restart();
    }

    public void DestroyObstacles()
    {
        ObstacleController[] obstacles = Object.FindObjectsOfType<ObstacleController>();
        foreach(ObstacleController obstacle in obstacles){
            obstacle.DestroySelf();
        }
    }
}
