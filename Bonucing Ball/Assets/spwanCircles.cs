using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine.EventSystems;

public class spwanCircles : MonoBehaviour
{
    static private Renderer rend;
    public GameObject circles;
    float randX;
    float randY;
    Vector2 whereToSpwan;
    public float spwanRate = 2f;
    float nextSpwan = 0.0f;
    static public int index = 0;
    int indSyb = 0;
    static public string[] array2 = { "dictionary", "fisherman", "system", "filter" };
    string word = "";

    // Start is called before the first frame update
    void Start()
    {
        updateCircle();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                checkWord(hit.collider.GetComponentInChildren<TextMesh>().text, hit.collider);
            }
        }
    }
    private int CountSyllables(string word)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
        string currentWord = word;
        int numVowels = 0;
        bool lastWasVowel = false;
        foreach (char wc in currentWord)
        {
            bool foundVowel = false;
            foreach (char v in vowels)
            {
                //don't count diphthongs
                if (v == wc && lastWasVowel)
                {
                    foundVowel = true;
                    lastWasVowel = true;
                    break;
                }
                else if (v == wc && !lastWasVowel)
                {
                    numVowels++;
                    foundVowel = true;
                    lastWasVowel = true;
                    break;
                }
            }
            //if full cycle and no vowel found, set lastWasVowel to false;
            if (!foundVowel)
                lastWasVowel = false;
        }
        //remove es, it's _usually? silent
        if (currentWord.Length > 2 &&
            currentWord.Substring(currentWord.Length - 2) == "es")
            numVowels--;
        // remove silent e
        else if (currentWord.Length > 1 &&
            currentWord.Substring(currentWord.Length - 1) == "e")
            numVowels--;

        return numVowels;
    }
    public string[] ListSyllables(string word)
    {
        string currentWord = word;
        string[] listSyllables = new string[CountSyllables(word)];
        var regex = @"[^aeiouy]*[aeiouy]+(?:[^aeiouy]*$|[^aeiouy](?=[^aeiouy]))?";

        for(int i = 0; i < listSyllables.Length; i++)
        {
            listSyllables[i] = Regex.Match(currentWord, regex, RegexOptions.IgnoreCase).Value;
            currentWord = currentWord.Replace(listSyllables[i], "");
        }
        return listSyllables;
    }
    static public void removeCircles()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag("circle");
        for (var i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);
    }
    public void updateCircle()
    {
        var list = ListSyllables(array2[index]);
        GameObject syllable = circles.transform.GetChild(0).gameObject;
        rend = circles.GetComponent<Renderer>();
        rend.sharedMaterial.color = Color.white;
        for (int i = 0; i < list.Length; i++)
        {
            nextSpwan = Time.time + spwanRate;
            randX = Random.Range(-17f, 14.7f);
            randY = Random.Range(-9f, 8.8f);
            whereToSpwan = new Vector2(randX, randY);
            syllable.GetComponentInChildren<TextMesh>().text = list[i];
            Instantiate(circles, whereToSpwan, Quaternion.identity);
        }
    }
    public void checkWord(string syllable, Collider2D obj)
    {
        var list = ListSyllables(array2[index]);
        
        if (Equals(list[indSyb], syllable))
        {
            changeColor(obj, Color.green);
            word += syllable;
            indSyb++;
        }else
        {
            changeColor(obj, Color.red);
        }
        if (Equals(array2[index], word))
        {
            indSyb = 0;
            word = "";
            removeCircles();
            if(array2.Length > index)
            {
                index += 1;
                updateCircle();
            }else
            {

            }
            scoreUpdate.scoreNum++;

        }
        Debug.Log(word);
    }
    public void changeColor(Collider2D obj, Color color)
    {
        rend = obj.GetComponent<Renderer>();
        rend.material.color = color;
    }

}
