using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeskTaskUI : MonoBehaviour
{
    [Header ("References to UI")]
    [SerializeField] TextMeshProUGUI[] buttontextRefs;  //This is an array so more buttons can be added, to display say 5 buttons or even a square grid if wanted.
    [SerializeField] TextMeshProUGUI[] taskInfotextRefs;
    public GameObject taskSelectionUI, taskDescriptionUI, quizscreenRef; //For setting active on ui elements, to switch which ui canvas is visible.
    [SerializeField] Quiz quizcodeRef;

    [Header ("Reference to all tasks")]
    [SerializeField] TaskBase[] tasks;
    [HideInInspector] public bool[] completedTasks;
    
    
    string[] taskNames;

    //These two variables are used for when the number of tasks that need to be displayed is greater than the number that can fit on screen.
    
    int currentStart = 0;
    int numPerPage = 3;
    int currentTask;
    


    private void Start()
    {
        completedTasks = new bool[tasks.Length];
        setButtonText(0,numPerPage); // initial initialisation will show the first 3 tasks on the first 3 buttons
    }
    public void NextPage() //Gets the next page of tasks to choose from
    {
        if(currentStart < tasks.Length - numPerPage) //if currentStart is less than it will be on the last page
        {
            currentStart += numPerPage; 
            setButtonText(currentStart, currentStart + numPerPage);
        }
       
    }

    public void PreviousPage() //go back a page to the previous set of tasks
    {
        if (currentStart > 0)
        {
            currentStart -= numPerPage;
            setButtonText(currentStart, currentStart + numPerPage);
        }
    }



    void setButtonText(int currentStart, int currentEnd)
    {
        int thisButton = 0;
        //This for loop gets every one of the buttons on the screen and applies a task to it in sequence
        for (int currentButton = currentStart; currentButton < currentEnd; currentButton++)
        {
            
            buttontextRefs[thisButton].text = tasks[currentButton].taskName;
            thisButton++;
        }
    }

    //This function is placed on buttons in the inspector
    public void showDescription(int whichButton) //gets all of the information for the task to display on screen. Which button is the button pressed
    {
        //gets a new int variable based on the task chosen by button clicked + the starting point to get the right task within the array of tasks above
        currentTask = currentStart + whichButton;
        if (!completedTasks[currentTask])
        {
            //first, remove the task selection ui and add the task description ui
            taskSelectionUI.SetActive(false);
            taskDescriptionUI.SetActive(true);

            //Gets the title
            taskInfotextRefs[0].text = buttontextRefs[whichButton].text;
            

            //gets the task description using the method above
            buttontextRefs[whichButton].text = tasks[currentTask].taskDescription;

            taskInfotextRefs[1].text = buttontextRefs[whichButton].text;

            //a switch statement for the different task types. More can be added at a later date as design progresses
            switch (tasks[currentTask].chosenType)
            {
                case 1: //For collecting items

                    break;
                case 2: //For questions
                        //create some local variables to use below
                    int localNumQ = NumQuestionsGet(currentTask);
                    int localTime = TimeGet(currentTask);
                    int localreward = RewardGet(currentTask);
                    //taskinfoTextRefs is an array so we just have to change a number rather than remember a lot of variabl names!
                    // string.format is clearer than a lot of "" + "" + .... etc
                    taskInfotextRefs[2].text = string.Format("Answer {0} questions in {1} seconds!", localNumQ.ToString(), localTime.ToString());
                    taskInfotextRefs[3].text = string.Format("Reward: {0} Coins", localreward.ToString());

                    break;
            }

        
        }
       
    }

    #region QuestionData
    //This function gets the number of questions to answer from the given task. Then will output this number to be written on the task picker UI.
    int NumQuestionsGet(int currentQuestionInfo)
    {
        int numQuestions = tasks[currentQuestionInfo].numberofQuestionstoAnswer;
        

        return numQuestions;
    }
    #endregion

    //Gets the amount of time the player has to complete the task.
    int TimeGet(int currentQuestionInfo)
    {
       int time =  tasks[currentQuestionInfo].timeAllowed;
        return time;
    }

    //Gets the reward amount the player will receive for completing the task
    int RewardGet(int currentQuestionInfo)
    {
        int reward = tasks[currentQuestionInfo].reward;
        return reward;
    }


    public void AcceptTask()
    {

        switch (tasks[currentTask].chosenType)
        {
            case 1: //For collecting items

                break;
            case 2: //For questions set the data for the player to access for the quiz
                quizcodeRef.thisTask = tasks[currentTask];
                quizcodeRef.SetData();
                quizcodeRef.taskNumber = currentTask;
                taskDescriptionUI.SetActive(false);
                quizscreenRef.SetActive(true);
                
                break;
        }
    }
}
