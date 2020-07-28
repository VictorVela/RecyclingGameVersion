using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fab_score : MonoBehaviour
{
    public Text Scoretext;
    public static int scoreValue = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = scoreValue.ToString();
    }

    public static void GameOver()
    {
        //Application.LoadLevel("Fabrica_reciclagem_08");
        //GameOver_fab.GameOver = true;
    }
}
