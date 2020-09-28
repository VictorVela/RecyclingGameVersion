using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeStart;
    public float newScreenTime = 10f;
    public bool warningTime;
    public double warningTimeMinute = 6;
    private bool finished = false;
    public bool playerDead = false;
    public bool gameFinished = false;
    public bool levelWithoutTime = false;
    
    public TextMeshProUGUI timer;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameFinished = false;
        warningTime = false;
        timeStart = 120f;
        if(gameObject.scene.name.Equals("Fase02"))
            timeStart = 1220f;
        timer.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameFinished)
        {
            newScreenTime -= Time.deltaTime;

            //string minutes = ((int)newScreenTime / 60).ToString();
            string seconds = (newScreenTime % 60).ToString("0");

            if (seconds.Equals("0"))
            {
                SceneManager.LoadScene("Points");
            }
            
        }
        if (finished)
        {
            timer.text = "0:00";
            gameFinished = true;
            gameController.TimeOver();
            return;
        }
        if (!playerDead)
        {
            if (PersonSelect.pause.Equals(false))
            {
                if (!levelWithoutTime)
                    timeStart -= Time.deltaTime;
            }            

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
