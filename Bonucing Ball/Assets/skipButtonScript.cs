using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skipButtonScript : MonoBehaviour
{
    public void changeWord()
    {
        if (spwanCircles.array2.Length > spwanCircles.index)
        {
            spwanCircles.index += 1;
        }
        Debug.Log(spwanCircles.index);
        spwanCircles.removeCircles();
    }

}
