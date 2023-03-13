using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int scorePlayer1, scorePlayer2;
    public ScoreText scoreTextLeft, scoreTextRight;
    public Action onReset;

    private void Awake()
    {
        if (instance)
        {
           Destroy(gameObject);
        }
        else
        {
            instance= this;
        }
    }
    public void OnScoreZoneReached (int id)
    {
        onReset?.Invoke();

        if (id == 1)
        {
            scorePlayer1++;
        }
        if (id == 2)
        {
            scorePlayer2++;
        }
        UpdateScores();
        HighlightScore(id);
    }
    private void UpdateScores()
    {
        scoreTextLeft.SetScore(scorePlayer1);
        scoreTextRight.SetScore(scorePlayer2);

    }

    public void HighlightScore (int id)
    {
        switch (id)
        {
            case 1:
                scoreTextLeft.Highlight();
                break;
            case 2: 
                scoreTextRight.Highlight();
                break;
                
        }
    }
}
