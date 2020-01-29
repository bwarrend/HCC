using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{

    public void quitApp()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
