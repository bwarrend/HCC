using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour
{
    public string ContentFromUrl;
    public string URLQuestions;
    public string URLAnswerKey;
    public string[] QuestionsAndAnswers = new string[100];
    
    //public ToggleGroup q1;

    void Start(){

        ContentFromUrl = getFromUrl(URLQuestions);

        Debug.Log(ContentFromUrl);

        QuestionsAndAnswers = ContentFromUrl.Split('\n');

        for(int i = 0; i < QuestionsAndAnswers.Length; ++i){
            Debug.Log(i + ":   " + QuestionsAndAnswers[i]);
        }
        

        
    }

    string getFromUrl(string url){
        
        WWW www = new WWW(url);
        

        float startTimer = Time.time;
        //This while loop could be dangerous so I added a timeout function
        // that should return to the computer scene if 5 seconds pass. UNTESTED.
        while(!www.isDone){
            float currentTime = Time.time;
            if(currentTime == startTimer+5){
                Debug.Log("WE TIMED OUT");
                SceneManager.LoadScene("Computer");                
            }
        }
        return www.text;
    }


    void Update() {
        //Debug.Log(ContentFromUrl);
        
    }



    /*

     * 
     * X-I want to make a public string array here.
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
     */ 

}
