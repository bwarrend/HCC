using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Option", menuName = "DialogueOptions")]
public class DialogueOptions : Dialogue
{
    [System.Serializable]
    public class Options
    {
        public string buttonName;
    }
    public Options[] optionsInfo;
}
