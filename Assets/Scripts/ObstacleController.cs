using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] public SharedVarFloat obstacleSpeedDifficulty;
    [SerializeField] public float yVariation;

    private ScoreController score_controller;
    private DifficultController difficult_controller;

    private Vector3 playerPos;
    private bool scored;

    
    private void Start(){
        transform.Translate(Vector3.up * Random.Range(-yVariation, yVariation));
        playerPos = GameObject.FindFirstObjectByType<PlayerController>().transform.position;
        score_controller = GameObject.FindFirstObjectByType<ScoreController>();
        difficult_controller = GameObject.FindFirstObjectByType<DifficultController>();
    }

    
    private void Update(){
        float obstacleSpeed = Mathf.Lerp(obstacleSpeedDifficulty.value, obstacleSpeedDifficulty.valuehard, difficult_controller.Difficulty);
        transform.Translate(Vector3.left * obstacleSpeed * Time.deltaTime);

        if(!scored && transform.position.x < playerPos.x)
        {
            scored = true;
            score_controller.AddScore();
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision){
        DestroySelf();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void CountScore()
    {
    }
}
