using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextFromURL : MonoBehaviour{

    public string url;
    public Text text;

    IEnumerator Start()
    {
        WWW www = new WWW(url);
        yield return www;
        text.text = www.text;
    }
}
