using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeScoreText : MonoBehaviour
{
    Text info;
    int score = 0;
    int min = 0;
    int sec = 0;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        info = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Cube");
        if(player != null)
        {

            CharController characterController = player.GetComponent<CharController>();
            score = characterController.score;
            time = Time.time;
            min = characterController.min;
            sec = characterController.sec;
            info.text = min.ToString("00") + ":" + sec.ToString("00") +" \n Score:"
                + score;
        }
    }
}
