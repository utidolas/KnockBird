using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceScript : MonoBehaviour
{
    [SerializeField] public GameObject text_gameOver;
    [SerializeField] private TextMeshProUGUI text_bestScore;
    [SerializeField] private Image posMedal;
    [SerializeField] private Sprite goldMedal;
    [SerializeField] private Sprite silverMedal;
    [SerializeField] private Sprite bronzeMedal;

    private ScoreController score_sontroller;

    int bestScore;

    private void Start()
    {
        score_sontroller = GameObject.FindFirstObjectByType<ScoreController>();
    }

    public void ShowInterface()
    {
        UpdateBestScore();
        text_gameOver.SetActive(true);
    }

    public void HideInterface()
    {
        text_gameOver.SetActive(false);
    }

    private void UpdateBestScore()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
        text_bestScore.text = bestScore.ToString();

        VerifyMedal();
    }

    private void VerifyMedal()
    {
        if (score_sontroller.Score > bestScore - 5)
        {
            posMedal.sprite = goldMedal;
        }
        else if(score_sontroller.Score > bestScore / 2)
        {
            posMedal.sprite = silverMedal;
        }
        else
        {
            posMedal.sprite = bronzeMedal;
        }
    }

}
