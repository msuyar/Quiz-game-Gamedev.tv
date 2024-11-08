using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
   [SerializeField] float timeToCompleteQuestion = 30f;
   [SerializeField] float TimeToShowCorrectAnswer = 10f; 
   bool isAnsweringQuestion = false;
   bool loadNextQuestion;
   float timerValue;
   float fillFraction;
 
    void Update()
    {
        UpdateTimer();
    }
    public void CancelTimer()
    {
        timerValue = 0;
    }
    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(timerValue > 0 && !isAnsweringQuestion)
        {
            fillFraction = timerValue / TimeToShowCorrectAnswer;
        }
        
        else if(timerValue > 0 && isAnsweringQuestion)
        {
            fillFraction = timerValue / timeToCompleteQuestion;
        }
        
        else if(timerValue <= 0 && !isAnsweringQuestion)
        {
            timerValue = timeToCompleteQuestion;
            isAnsweringQuestion = !isAnsweringQuestion;
            loadNextQuestion = true;
        }
        
        else if(timerValue <= 0 && isAnsweringQuestion)
        {
            timerValue = TimeToShowCorrectAnswer;
            isAnsweringQuestion = !isAnsweringQuestion;
        }
        
        //Debug.Log(isAnsweringQuestion + " timervalue: " + timerValue + " fillFraction = " + fillFraction);
    }
    public bool GetisAnsweringQuestion()
    {
        return isAnsweringQuestion;
    }
    public float GetfillFraction()
    {
        return fillFraction;
    }
    public bool GetloadNextQuestion()
    {
        return loadNextQuestion;
    }
    public void SetloadNextQuestion(bool newState)
    {
        loadNextQuestion = newState;
    }
}
