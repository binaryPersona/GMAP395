using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text score;
    private int scoreCount;

    // Use this for initialization
    void Start()
    {
        scoreCount = 0;
        score.text = "Score:0";
    }

    public void AddScore(int points)
    {
        scoreCount += points;
        score.text = "Score:" + scoreCount;
    }
}
