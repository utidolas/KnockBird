using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceScript : MonoBehaviour
{
    [SerializeField] public GameObject text_gameOver;
    [SerializeField] private TextMeshProUGUI text_bestScore;

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
        int bestScore = PlayerPrefs.GetInt("bestScore");
        text_bestScore.text = bestScore.ToString();
    }

}
