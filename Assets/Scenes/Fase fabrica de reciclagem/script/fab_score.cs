﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class fab_score : MonoBehaviour
{
    //AUDIO
    public static AudioClip coinsound;
    static AudioSource audioSrc;

    public Text Scoretext;
    public Text FinalScore;
    public static int scoreValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        coinsound = Resources.Load<AudioClip>("coins");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void playSound()
    {
        audioSrc.PlayOneShot(coinsound);
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = scoreValue.ToString();
        FinalScore.text = scoreValue.ToString();
    }

    public static void GameOver()
    {
        //Application.LoadLevel("Fabrica_reciclagem_08");
        GameOver_fab.GameOver = true;
    }

    public static void GameOverSendScore(int fase, int pontuacao)
    {
        GameOver_fab.GameOver = true;
        Rest_Score score = new Rest_Score();
       // score.OnSendScore(fase, pontuacao);

    }

    public  void NewGame()
    {
        scoreValue = 0;
        GameOver_fab.NewGame = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
