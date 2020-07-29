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
            points.text = "Só, " + pointPlayer + " pontos? Vamos de novo...";
        }
        if (pointPlayer < 15 && pointPlayer > 5)
        {
            points.text = "Da pra melhorar... " + pointPlayer + " pontos!";
        }
        if(pointPlayer < 30 && pointPlayer > 14)
        {
            points.text = "Mandou bem, " + pointPlayer + " pontos!";
        }
        if(pointPlayer > 30)
        {
            points.text = "Ótima partida, " + pointPlayer + " pontos!";
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
