using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 180f;
    bool sendOneTimeScore = true;

    [SerializeField] Text countdownText;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(countdownText.text == "0" )
        {
            if (sendOneTimeScore)
            {
                sendOneTimeScore = false;
                fab_score.GameOverSendScore(83, 300);
            }
           
        }
    }
}
