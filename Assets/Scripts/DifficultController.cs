using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultController : MonoBehaviour
{
    [SerializeField] public float timeToMaxDifficult;
    private float timeElapsed;
    public float Difficulty {get; private set;}
    void Start()
    {
        
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        Difficulty = timeElapsed / timeToMaxDifficult;
        Difficulty = Mathf.Min(1, Difficulty);
    }

    public void Restart()
    {
        timeElapsed = 0;
    }
}
