using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int rightAnswerIndex;
    bool hasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite rightAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    
    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scorekeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;
    public bool isComplete = false;
    
    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scorekeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        progressBar.maxValue = questions.Count;
        progressBar.value = 0; 
    }

      void Update()
    {
        timerImage.fillAmount = timer.GetfillFraction();
        if(timer.GetloadNextQuestion())
        {
            if(progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }

            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.SetloadNextQuestion(false);
        }
        else if(!timer.GetisAnsweringQuestion() && !hasAnsweredEarly)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + scorekeeper.CalculateScore() + "%";

        
    }
 
    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();
        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }
 
    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
 
    void GetNextQuestion()
    {
        if(questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            scorekeeper.IncrementquestionsSeen();
            progressBar.value++;
        }
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if(questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }
    void SetDefaultButtonSprites()
    {
        
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage;
            buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
    void DisplayAnswer(int index)
    {
        Image buttonImage;
        if(index == currentQuestion.GetrightAnswerIndex())
        {
            questionText.text = "Correct";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = rightAnswerSprite;
            scorekeeper.IncrementCorrectAnswers();
        }
        else
        {
            rightAnswerIndex = currentQuestion.GetrightAnswerIndex();
            questionText.text = "Correct answer was: " + currentQuestion.GetAnswer(rightAnswerIndex);
            buttonImage = answerButtons[rightAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = rightAnswerSprite;
        }
    }
}
