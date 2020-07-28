using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeStart;
    public bool warningTime;
    public double warningTimeMinute = 6;
    private bool finished = false;
    public bool playerDead = false;
    
    public TextMeshProUGUI timer;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        warningTime = false;
        timeStart = 120f;
        timer.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            timer.text = "0:00";
            gameController.GameOver();
            return;
        }
        if (!playerDead)
        {
            timeStart -= Time.deltaTime;

            string minutes = ((int)timeStart / 60).ToString();
            string seconds = (timeStart % 60).ToString("0");

            timer.text = minutes + ":" + seconds;
            warningTime = timeWarningTest(minutes);

            if (seconds.Equals("0") && minutes.Equals("0"))
            {
                finished = true;
            }
        }
    }

    public bool timeWarningTest(string minutes)
    {
        if((int.Parse(minutes) < warningTimeMinute))
        {
            return true;
        } return false;
    }
}
