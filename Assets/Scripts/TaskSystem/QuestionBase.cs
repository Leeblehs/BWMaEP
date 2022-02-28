using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Question")] //Adds a right click option in the explorer called "Question".
public class QuestionBase : ScriptableObject //scriptable objects can be easily created on mass.
{
    [TextArea(6,10)] public string Question;
    [TextArea(3, 10)] public string Answer1;
    [TextArea(3, 10)] public string Answer2;
    [TextArea(3, 10)] public string Answer3;
    [TextArea(3, 10)] public string Answer4;

    [Range(1,4)]public int rightAnswer;
}
