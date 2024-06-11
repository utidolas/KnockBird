using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerController : MonoBehaviour
{
    [SerializeField] public GameObject obstacle;
    [SerializeField] public float timeToGenObstacleEasy;
    [SerializeField] public float timeToGenObstacleHard;
    private float counter;

    private DifficultController difficult_controller;

    void Start()
    {
        counter = timeToGenObstacleEasy;
        difficult_controller = FindFirstObjectByType<DifficultController>();
    }

    void Update()
    {
        counter -= Time.deltaTime;

        if(counter < 0){
            GameObject.Instantiate(obstacle, transform.position, Quaternion.identity);
            counter = Mathf.Lerp(timeToGenObstacleEasy, timeToGenObstacleHard, difficult_controller.Difficulty); 
        }
    }
}
