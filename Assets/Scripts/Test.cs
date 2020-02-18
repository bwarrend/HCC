using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public string[100] TestContent;
    public ToggleGroup q1;

    void Start()
    {
        
    }

    /*
     * Okay so, I have to write this down because I keep trying to write 
     * code and then I think about something I need to code later and then
     * forget about what I was originally trying to code;
     * 
     * -I want to make a public string array here.
     * -Then pull the questions/answers .txt from website
     * -Split it into the array based on '\n' escape character
     * -Set the text of the questions/answers based on string
     *      -TestContent[0] = First question
     *      -TestContent[1] = Question 1 answer 1
     *      -TestContent[2] = Question 1 answer 2
     *      -etc.
     * -Pull answer key to answers[] array
     * -Make boolean array for questions right and wrong, set all to false
     * -Once submit button is pressed, check each answer based on the toggle group
     *      -ToggleGroup Question_1;
     *      - if(Question_1.AnyTogglesOn()){
     *              Toggle answer = Question_1.ActiveToggles()???
     *              
     *              if (answer == answers[the questions]){
     *                     correct[the question] = true;
     *              }
     *         }
     *  
     *  -Show score and then maybe display incorrect questions here
     *  

}
