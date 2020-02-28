using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{
    
    public static DialogueManager instance;
    private void Awake()
    {

        if (instance != null)
        {
            //Debug.LogWarning("fix this " + gameObject.name);
        }
        else
        {
            instance = this;
        }


    }


    public GameObject dialogueBox;

    public Text dialogueName;
    public Text dialogueText;
    public Image dialoguePortrait;
    public float delay = 0.0001f;
    public string nextScene;

    public Queue<Dialogue.Info> dialogueInfo = new Queue<Dialogue.Info>();

    public void EnqueueDialogue(Dialogue db)
    {
        dialogueBox.SetActive(true);
        dialogueInfo.Clear();
        foreach(Dialogue.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }
        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if (dialogueInfo.Count == 0)
        {
            EndOfDialogue();
            return;
        }
        Dialogue.Info info = dialogueInfo.Dequeue();

        dialogueName.text = info.name;

        WWW www = new WWW(info.url);
        while(!www.isDone){
            //Downloading the wwww assets
        }
        string text = www.text;
        info.myText = text;
 
        dialogueText.text = info.myText;
        dialoguePortrait.sprite = info.portrait;

        StartCoroutine(TypeText(info));
    }

    IEnumerator TypeText(Dialogue.Info info)
    {
        dialogueText.text = "";
        foreach(char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
            yield return null;
        }
    }

    public void EndOfDialogue()
    {
        dialogueBox.SetActive(false);
        SceneManager.LoadScene(nextScene);
    }


    //public Text nameText;
    //public Text dialogueText;

    //public Animator animator;

    //private Queue<string> sentences;


    //// Start is called before the first frame update
    //void Start()
    //{
    //    sentences = new Queue<string>();
    //}

    //public void StartDialogue (Dialogue dialogue)
    //{
    //    animator.SetBool("IsOpen", true);
    //    nameText.text = dialogue.name;
    //    sentences.Clear();
    //    foreach (string sentence in dialogue.sentences)
    //    {
    //        sentences.Enqueue(sentence);
    //    }
    //    DisplayNextSentence();
    //}

    //public void DisplayNextSentence()
    //{
    //    if (sentences.Count == 0)
    //    {
    //        EndDialogue();
    //        return;
    //    }
    //    string sentence = sentences.Dequeue();
    //    StopAllCoroutines();
    //    StartCoroutine(TypeSentence(sentence));

    //}
    //IEnumerator TypeSentence (string sentence)
    //{
    //    dialogueText.text = "";
    //    foreach(char letter in sentence.ToCharArray())
    //    {
    //        dialogueText.text += letter;
    //        yield return null;
    //    }
    //}


    //void EndDialogue()
    //{
    //    animator.SetBool("IsOpen", false);
    //}

}
