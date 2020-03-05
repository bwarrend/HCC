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
    private bool isCurrentlyTyping;
    private string completeText;
    public string nextScene;

    public Queue<Dialogue.Info> dialogueInfo = new Queue<Dialogue.Info>();

    private bool isDialogueOption;
    public GameObject dialogueOptionUI;
    private bool inDialogue;
    public GameObject[] optionButtons;
    private int optionsAmount;

    public void EnqueueDialogue(Dialogue db)
    {
        if (inDialogue) return;
        inDialogue = true;

        dialogueBox.SetActive(true);
        dialogueInfo.Clear();

        if (db is DialogueOptions)
        {
            isDialogueOption = true;
            DialogueOptions dialogueOptions = db as DialogueOptions;
            optionsAmount = dialogueOptions.optionsInfo.Length;
        }
        else
        {
            isDialogueOption = false;
        }

        foreach(Dialogue.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }
        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if (isCurrentlyTyping == true)
        {
            CompleteText();
            StopAllCoroutines();
            isCurrentlyTyping = false;
            return;
        }

        if (dialogueInfo.Count == 0)
        {
            EndOfDialogue();
            return;
        }

        
        Dialogue.Info info = dialogueInfo.Dequeue();
        completeText = info.myText;

        dialogueName.text = info.name;


        pullTextUrl(info);
 
        dialogueText.text = info.myText;
        dialoguePortrait.sprite = info.portrait;
        dialogueText.text = "";
        StartCoroutine(TypeText(info));


    }

    IEnumerator pullTextUrl(Dialogue.Info info){
        //Disable annoying obsolete warning
        #pragma warning disable 0618
        
        WWW www = new WWW(info.url);
        yield return www;
        string text = www.text;
        info.myText = text;

        //Restore warnings
        #pragma warning restore 0618
    }
    IEnumerator TypeText(Dialogue.Info info)
    {
        isCurrentlyTyping = true;
        foreach(char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
        }
        isCurrentlyTyping = false;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }

    public void EndOfDialogue()
    {
        dialogueBox.SetActive(false);
        inDialogue = false;
        OptionsLogic();
        //SceneManager.LoadScene(nextScene);
    }

    private void OptionsLogic()
    {
        if (isDialogueOption == true)
        {
            dialogueOptionUI.SetActive(true);
            for (int i = 0; i < optionsAmount; i++)
            {
                optionButtons[i].SetActive(true);
            }
        }
    }
}
