using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] public float obstacleSpeed;
    [SerializeField] public float yVariation;

    private ScoreController score_controller;

    private Vector3 playerPos;
    private bool scored;

    // Start is called before the first frame update
    private void Start(){
        transform.Translate(Vector3.up * Random.Range(-yVariation, yVariation));
        playerPos = GameObject.FindFirstObjectByType<PlayerController>().transform.position;
        score_controller = GameObject.FindFirstObjectByType<ScoreController>();
    }

    // Update is called once per frame
    private void Update(){
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
