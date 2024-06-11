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
    public int Score { get; private set; }

    private void Start()
    {
        audio_score = GetComponent<AudioSource>();  
    }

    public void AddScore()
    {
        Score++;
        audio_score.Play();
        textScore.text = string.Format("{0}", Score);
    }

    public void ResetScore()
    {
        textScore.text = "0";
        Score = 0;
    }

    public void StoreScore()
    {
        int currentBestScore = PlayerPrefs.GetInt("bestScore");
        if(Score > currentBestScore){
            PlayerPrefs.SetInt("bestScore", Score);
        }
    }
}
