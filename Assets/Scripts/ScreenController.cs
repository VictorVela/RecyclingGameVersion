﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject screen4;
    public GameObject screen5;

    private string levelName;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Next()
    {
        screen1.GetComponent<Animator>().Play("GoLeft");
        screen2.GetComponent<Animator>().Play("GoLeft2");
    }

    public void Back()
    {
        screen2.GetComponent<Animator>().Play("GoRight2");
        screen1.GetComponent<Animator>().Play("GoRight");
    }
    public void SelectBoy()
    {
        PersonSelect.selectedPerson = "Boy";
        SceneManager.LoadScene(levelName);
    }
    public void SelectGirl()
    {
        PersonSelect.selectedPerson = "Girl";
        SceneManager.LoadScene(levelName);
    }

    public void GameStart()
    {
        //SceneManager.LoadScene(levelName);
    }

    public void StartFase01()
    {
        //SceneManager.LoadScene("Fase01");
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen1.GetComponent<Animator>().Play("FadeOut");
        levelName = "Fase31";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
    }

    public void StartFase02()
    {
        //SceneManager.LoadScene("Fase02");
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen1.GetComponent<Animator>().Play("FadeOut");
        levelName = "Fase02";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
    }

    public void StartFase03()
    {
        //SceneManager.LoadScene("Fase03");
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen1.GetComponent<Animator>().Play("FadeOut");
        //levelName = "Fase03";
        levelName = "Fase04";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
    }

    public void StartFase04()
    {
        //SceneManager.LoadScene("Fase04");
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen1.GetComponent<Animator>().Play("FadeOut");
        //levelName = "Fase04";
        levelName = "Fase06";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
    }
    public void StartFase05()
    {
        //SceneManager.LoadScene("Fase05");
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen1.GetComponent<Animator>().Play("FadeOut");
        //levelName = "Fase04";
        levelName = "Fase07";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        levelName = "Fabrica_reciclagem_01";
        SceneManager.LoadScene(levelName);
    }
    public void StartFase06()
    {
        //SceneManager.LoadScene("Fase06");
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fase06";
        //levelName = "Fase09";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
    }
    
    public void StartFase07()
    {
        //SceneManager.LoadScene("Fase07");
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        //levelName = "Fase07";
        levelName = "Fase10";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
    }
    public void StartFase08()
    {

        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fase08";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
    }
    public void StartFase09()
    {
        /*screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fase09";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();*/
        //screen1.GetComponent<Animator>().Play("FadeInPerson");
        levelName = "Fabrica_reciclagem_05";
        SceneManager.LoadScene(levelName);
    }

    public void StartFase10()
    {
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fase10";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
    }

    public void MouseInsideGirl()
    {
        screen4.gameObject.GetComponent<CanvasGroup>().alpha = 0;
    }
    public void MouseOutsideGirl()
    {
        screen4.gameObject.GetComponent<CanvasGroup>().alpha = 1;
    }
    public void MouseInsideBoy()
    {
        screen5.gameObject.GetComponent<CanvasGroup>().alpha = 0;
    }
    public void MouseOutsideBoy()
    {
        screen5.gameObject.GetComponent<CanvasGroup>().alpha = 1;
    }
}
