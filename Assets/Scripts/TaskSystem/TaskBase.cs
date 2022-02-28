using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Task")]
public class TaskBase : ScriptableObject
{
    public string taskName;
    [TextArea(2,10)] public string taskDescription;
    //public enum taskType {CollectItem, AnswerQuestions};
    //public taskType chosenType;
    [Tooltip("1 = Collection" +
        "      2 = Answer Questions")]public int chosenType;
    public int timeAllowed;
    public int reward;



    [Header("For Collect")]
    [SerializeField] GameObject[] objecstToCollect;


    [Header("For Answer Questions")]
    public int numberofQuestionstoAnswer;
    public QuestionBase[] questions;


    


}
