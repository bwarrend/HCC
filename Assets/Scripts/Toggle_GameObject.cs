using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_GameObject : MonoBehaviour
{
    public GameObject gameobject;

    public void OpenPanel()
    {
        if (gameobject != null)
        {
            bool isActive = gameobject.activeSelf;
            gameobject.SetActive(!isActive);
        }
    }
}
  