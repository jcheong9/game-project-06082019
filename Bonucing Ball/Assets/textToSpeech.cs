using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textToSpeech : MonoBehaviour
{
    public AudioSource _audio;
    public InputField inputText;
    string text = "WRONG";

    // Start is called before the first frame update
    void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DownloadTheAudio()
    {
        //text = array2[index];
        string url = "https://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q="+text+"&tl=En-gb";
        WWW www = new WWW(url);

        yield return www;

        _audio.clip = www.GetAudioClip(false, true, AudioType.MPEG);
        _audio.Play();
    }

    public void ButtonPlayAudio()
    {
        StartCoroutine(DownloadTheAudio());
    }

}
