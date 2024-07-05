using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    private int maxScore;
    private int score;

    public int FinalScore => score;

    public int MaxScore => maxScore;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int n)
    {
        score += n;
    }

    public void SetMaxScore(int number)
    {
        if(number < 0)
            throw new ArgumentOutOfRangeException();

        maxScore = number;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
