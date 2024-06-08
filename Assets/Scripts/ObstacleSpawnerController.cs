using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerController : MonoBehaviour
{
    [SerializeField] public GameObject obstacle;
    [SerializeField] public float timeToGenObstacle;
    private float counter;

    void Start()
    {
        counter = timeToGenObstacle;
    }

    void Update()
    {
        counter -= Time.deltaTime;

        if(counter < 0){
            GameObject.Instantiate(obstacle, transform.position, Quaternion.identity);
            counter = timeToGenObstacle;
        }
    }
}
