using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameScript : MonoBehaviour
{
    private ParallaxController[] parallax_controller;
    private ObstacleSpawnerController obstacleSpawner_controller;

    private void Start()
    {
        parallax_controller = GetComponentsInChildren<ParallaxController>();
        obstacleSpawner_controller = GetComponentInChildren<ObstacleSpawnerController>();
    }

    public void Deactivate()
    {
        foreach (var backgroundParallax in parallax_controller)
        {
            backgroundParallax.enabled = false;
        }
        obstacleSpawner_controller.StopGen();
    }

}
