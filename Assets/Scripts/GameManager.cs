using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndGameScoreText endGameScoreText;

    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endGameScoreText = FindObjectOfType<EndGameScoreText>();
        quiz.gameObject.SetActive(true);
        endGameScoreText.gameObject.SetActive(false);
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        if(quiz.isComplete)
        {
            quiz.gameObject.SetActive(false);
            endGameScoreText.gameObject.SetActive(true);
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
