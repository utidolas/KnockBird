using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] public float obstacleSpeed;
    [SerializeField] public float yVariation;

    // Start is called before the first frame update
    private void Start(){
        transform.Translate(Vector3.up * Random.Range(-yVariation, yVariation));
    }

    // Update is called once per frame
    private void Update(){
        transform.Translate(Vector3.left * obstacleSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        DestroySelf();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
