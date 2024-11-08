using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    int questionsSeen = 0;
  
    public int GetcorrectAnswers()
    {
        return correctAnswers;
    }
    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }
    public int GetquestionsSeen()
    {
        return questionsSeen;
    }
    public void IncrementquestionsSeen()
    {
        questionsSeen++;
    }
    public int CalculateScore()
    {
        return Mathf.RoundToInt((correctAnswers / (float)questionsSeen) * 100); 
    }
}
