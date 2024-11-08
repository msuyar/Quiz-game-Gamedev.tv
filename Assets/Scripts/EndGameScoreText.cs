using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EndGameScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endGameScoreText;
    ScoreKeeper scoreKeeper;
    
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        
    }
    void Start()
    {
        CalculateFinalScore();
    } 
    void Update()
    {
        
    }
    public void CalculateFinalScore()
    {
        endGameScoreText.text = "Your score is: " + scoreKeeper.CalculateScore() + "%";
        Debug.Log(scoreKeeper.CalculateScore());
    }
}
