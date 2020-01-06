using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//singleton used to track the index of list of words
public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript Instance { get; set; }

    public int index = 0;
    public string[] listWords = { "dictionary", "fisherman", "system", "filter" };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
