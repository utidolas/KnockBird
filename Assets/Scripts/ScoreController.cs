using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textScore;
    private AudioSource audio_score;
    private int score;

    private void Start()
    {
        audio_score = GetComponent<AudioSource>();  
    }

    public void AddScore()
    {
        score++;
        audio_score.Play();
        textScore.text = string.Format("{0}", score);
    }

    public void ResetScore()
    {
        textScore.text = "0";
        score = 0;
    }

    public void StoreScore()
    {
        int currentBestScore = PlayerPrefs.GetInt("bestScore");
        if(score > currentBestScore){
            PlayerPrefs.SetInt("bestScore", score);
        }
    }
}
