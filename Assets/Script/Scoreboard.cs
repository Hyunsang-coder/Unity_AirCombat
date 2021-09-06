using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public int score;
    TMP_Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start!";    /// .text�� text â
    }


    public void IncreaseScore(int scoreUp)
    {
        score += scoreUp;
        scoreText.text = "Score: " + score.ToString();
    }

}
