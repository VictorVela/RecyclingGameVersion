using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointScreen : MonoBehaviour
{
    public TextMeshProUGUI points;
    public static int pointPlayer;

    void Start()
    {
        if (pointPlayer < 5)
        {
            points.text = "Conseguiu " + pointPlayer + " sementes! Vamos de novo?";
        }
        if (pointPlayer < 15 && pointPlayer > 5)
        {
            points.text = "Legal, " + pointPlayer + " sementes!";
        }
        if(pointPlayer < 30 && pointPlayer > 14)
        {
            points.text = "Mandou bem, " + pointPlayer + " sementes!";
        }
        if(pointPlayer > 30)
        {
            points.text = "Excelente, " + pointPlayer + " sementes!";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
