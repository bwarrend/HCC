using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Quiz : MonoBehaviour{
    public string ContentFromUrl;
    public string URLQuestions;
    public string URLAnswerKey;
    public static string[] QuestionsAndAnswers = new string[100];
    public static string[] answerKey = new string[20];
    public static string[] userAnswers;
    public static bool[] correctIncorrect;
    public GameObject scorePanel;
    public Text scoreText;
    public Text correctAnswersText;
    public Text questionsText;

    private int correctAnswers = 0;
    private const int maxQuestions = 20;
    private double score;

    public ToggleGroup[] toggleGroups = new ToggleGroup[20];

    void Start(){


        //Pull  quiz from online and store in one giant string
        ContentFromUrl = getFromUrl(URLQuestions);

        /* DEBUG
        Debug.Log(ContentFromUrl);
        */

        //Split the string into an array based on newline
        QuestionsAndAnswers = ContentFromUrl.Split('\n');

        /* DEBUG
        for(int i = 0; i < QuestionsAndAnswers.Length; ++i){
            Debug.Log(i + ":   " + QuestionsAndAnswers[i]);
        }
        */

        //Get answer key and store in one string
        ContentFromUrl = getFromUrl(URLAnswerKey);
        
        //Split string into array based on newline
        answerKey = ContentFromUrl.Split('\n');
        userAnswers = new string[20];
        correctIncorrect = new bool[20];


    }

    string getFromUrl(string url){
        
        #pragma warning disable 0618 //Remove annoying warning
        WWW www = new WWW(url);
        #pragma warning restore 0618 //Restore future warnings
        

        float startTimer = Time.time;
        //This while loop could be dangerous so I added a timeout function
        // that should return to the computer scene if 5 seconds pass. UNTESTED.
        while(!www.isDone){
            float currentTime = Time.time;
            if(currentTime == startTimer+5){
                Debug.Log("WE TIMED OUT");
                SceneManager.LoadScene("Computer");
                //Ideally we should tell the user and also make sure they don't lose progress / still have access to quiz              
            }
        }
        return www.text;
    }


    public void Submit_Quiz(){
        correctAnswers = 0;
        //Pull all the answers from the Quiz and store them as A-D in an array called userAnswers
        for(int i = 0; i < toggleGroups.Length; ++i){
            userAnswers[i] = getAnswerFromGroup(toggleGroups[i]);
        }


        /* DEBUG
        for(int i = 0; i < userAnswers.Length; ++i){
            Debug.Log(userAnswers[i]);
        }
        */


        for(int i = 0; i < userAnswers.Length; ++i){
            if(userAnswers[i] == answerKey[i]){
                correctIncorrect[i] = true;
                correctAnswers++;
            }
        }
        /* DEBUG
        for(int i = 0; i < correctIncorrect.Length; ++i){
             if (correctIncorrect[i]){
                 Debug.Log(i + ": CORRECT");
             }else{
                 Debug.Log(i + ": WRONG");
             }
        }
        */

        score = ((double)correctAnswers / (double)maxQuestions) * 100;

        /* DEBUG
        Debug.Log("Correct Answers: " + correctAnswers);
        Debug.Log("Max Questions: " + maxQuestions);
        Debug.Log("Score: " + score + "%");
        */

        //Enable score overview
        scorePanel.SetActive(!scorePanel.activeSelf);
        
        scoreText.text = "Score: " + score + "%";
        correctAnswersText.text = "Correct Answers: " + correctAnswers;
        questionsText.text = "Questions: " + maxQuestions;
        
        
    }

    string getAnswerFromGroup(ToggleGroup TG){
        Toggle answer = TG.ActiveToggles().FirstOrDefault();
        string letterAnswer = "E";

        if(!TG.AnyTogglesOn()){
            return letterAnswer;
        }

        switch(answer.name){
            case "Toggle_A":
                letterAnswer = "A";
                break;
            case "Toggle_B":
                letterAnswer = "B";
                break;
            case "Toggle_C":
                letterAnswer = "C";
                break;
            case "Toggle_D":
                letterAnswer = "D";
                break;
            default:
                break;
        }

        return letterAnswer;
    }



    /*

     * 
     * X-I want to make a public string array here.
     * X-Then pull the questions/answers .txt from website
     * X-Split it into the array based on '\n' escape character
     * X-Set the text of the questions/answers based on string
     *      -TestContent[0] = First question
     *      -TestContent[1] = Question 1 answer 1
     *      -TestContent[2] = Question 1 answer 2
     *      -etc.
     * x-Pull answer key to answers[] array
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
