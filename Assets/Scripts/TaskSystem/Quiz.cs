using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI[] answerTextRefs;
    [SerializeField] PlayerUI playerUIRef;
    [HideInInspector]public TaskBase thisTask;
    QuestionBase[] questions;
    int time;
    int correctAnswer;
    int questionIndex = 0;
    int thisReward;
    Coroutine timer = null;

    

    public void SetData()
    {
        questions = thisTask.questions;
        
        time = thisTask.timeAllowed;
        thisReward = thisTask.reward;
        
       timer = playerUIRef.StartCoroutine(playerUIRef.Timer(time));
        GetQuestion();
    }

    void GetQuestion()
    {
        QuestionBase currentQuestion = questions[questionIndex];
        questionText.text = currentQuestion.Question;
        answerTextRefs[0].text = currentQuestion.Answer1;
        answerTextRefs[1].text = currentQuestion.Answer2;
        answerTextRefs[2].text = currentQuestion.Answer3;
        answerTextRefs[3].text = currentQuestion.Answer4;
        correctAnswer = currentQuestion.rightAnswer;
        
        
    }

    public void ChosenAnswer(int picked)
    {
        if(picked == correctAnswer)
        {
            Debug.Log("Right!");
            if(questionIndex == questions.Length - 1)
            {
                Debug.Log("All questions answered!");
                playerUIRef.AddCoins(thisReward);
                playerUIRef.StopCoroutine(timer);
            }
            else
            {
                questionIndex++;
                GetQuestion();
            }
            
        }
        else
        {
            Debug.Log("Wrong!");
        }
    }

    

}
