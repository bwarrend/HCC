using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailManager : MonoBehaviour
{

    public void DeleteObject(GameObject item)
    {
        Destroy(item.gameObject);
    }

    //public void DeleteEmail(EmailObject email)
    //{
    //    emailObjects.Remove(email);
    //    Destroy(email.gameObject);
    //}
}
