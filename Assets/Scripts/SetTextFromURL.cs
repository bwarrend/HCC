using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextFromURL : MonoBehaviour{

    public string url;
    public Text text;

    IEnumerator Start()
    {
        //Disable the annoying obsolete message
        #pragma warning disable 0618
        
        WWW www = new WWW(url);
        yield return www;
        text.text = www.text;

        //Restore warnings
        #pragma warning restore 0618
    }
}
