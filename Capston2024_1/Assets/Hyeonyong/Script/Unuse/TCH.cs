using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TCH : MonoBehaviour
{
    // Start is called before the first frame update

    //public TextMeshProUGUI t;
    void Start()
    {
        //t.text = "<color=#ff3939>text</color>";


        SoundManager.Instance.PlayTTS(SoundManager.TTS_list.TUTORIAL_WATER_QUIZ_2_X);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
