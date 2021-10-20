using UnityEngine;
using UnityEngine.UI;
using System;

// see: https://www.youtube.com/watch?v=YUcvy9PHeXs&ab_channel=CocoCode
public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public static int score;

    public static ScoreManager instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public int getScore() {
        return  Convert.ToInt32(scoreText.text);
    }

    public void increaseScore(int score) {
        scoreText.text = (getScore() + score).ToString();
    }

    public void setScore(int score) {
        scoreText.text = score.ToString();
    }
}
