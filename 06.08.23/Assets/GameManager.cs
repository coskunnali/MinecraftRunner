using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float highScore = 0;
    private float currentScore = 0;
    public Text scoreText;
    public Text highScoreText;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        scoreText.text = string.Format("Score: {0}", currentScore.ToString());
        highScoreText.text = string.Format("HIGHSCORE: {0}", highScore.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = string.Format("Score: {0}", currentScore.ToString());
        //highScoreText.text = string.Format("HIGHSCORE: {0}", highScore.ToString());
    }

    public void AddScore(float value)
    {
        currentScore += value;
        scoreText.text = string.Format("Score: {0}", currentScore.ToString());
        if (currentScore >= highScore) {
            highScore = currentScore;
            highScoreText.text = string.Format("HIGHSCORE: {0}", highScore.ToString());
            PlayerPrefs.SetFloat("HighScore", currentScore);
        }
        else
        {
            highScoreText.text = string.Format("HIGHSCORE: {0}", highScore.ToString());
        }
    }
}
