using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skipButtonScript : MonoBehaviour
{
    public void changeWord()
    {
        if (PersistentManagerScript.Instance.listWords.Length > PersistentManagerScript.Instance.index)
        {
            PersistentManagerScript.Instance.index += 1;
        }
        Debug.Log(PersistentManagerScript.Instance.index);
        spwanCircles.removeCircles();
    }

}
