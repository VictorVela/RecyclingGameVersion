using System.Collections;
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
    public GameObject test;
    

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
        levelName = "Fase01";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        test.gameObject.SetActive(false);
    }

    public void StartFase02()
    {
        //SceneManager.LoadScene("Fase02");
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen1.GetComponent<Animator>().Play("FadeOut");
        levelName = "Fase02";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        test.gameObject.SetActive(false);
    }

    public void StartFase03()
    {
        //SceneManager.LoadScene("Fase03");
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen1.GetComponent<Animator>().Play("FadeOut");
        levelName = "Fase03";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        test.gameObject.SetActive(false);
    }

    public void StartFase04()
    {
        //SceneManager.LoadScene("Fase04");
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen1.GetComponent<Animator>().Play("FadeOut");
        levelName = "Fase04";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        test.gameObject.SetActive(false);
    }
    public void StartFase05()
    {
        //SceneManager.LoadScene("Fase05");
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen1.GetComponent<Animator>().Play("FadeOut");
        levelName = "Fase05";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        /*levelName = "Fabrica_reciclagem_01";
        SceneManager.LoadScene(levelName);*/
        test.gameObject.SetActive(false);
    }
    public void StartFase06()
    {
        //SceneManager.LoadScene("Fase06");
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fase06";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        test.gameObject.SetActive(false);
    }
    
    public void StartFase07()
    {
        //SceneManager.LoadScene("Fase07");
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fase07";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        test.gameObject.SetActive(false);
    }
    public void StartFase08()
    {
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fase08";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        test.gameObject.SetActive(false);
    }
    public void StartFase09()
    {
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fase09";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        screen1.GetComponent<Animator>().Play("FadeInPerson");
        test.gameObject.SetActive(false);
        /*levelName = "Fabrica_reciclagem_05";
        SceneManager.LoadScene(levelName);*/
    }

    public void StartFase10()
    {
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fase10";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        screen1.GetComponent<Animator>().Play("FadeInPerson");
        test.gameObject.SetActive(false);
    }

    public void StartFase11()
    {
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fase11";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        screen1.GetComponent<Animator>().Play("FadeInPerson");
        test.gameObject.SetActive(false);
    }

    public void StartFase12()
    {
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fase12";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        screen1.GetComponent<Animator>().Play("FadeInPerson");
        test.gameObject.SetActive(false);
    }

    public void StartFase13()
    {
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fase13";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        screen1.GetComponent<Animator>().Play("FadeInPerson");
        test.gameObject.SetActive(false);
    }

    public void StartFase14()
    {
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fase14";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        screen1.GetComponent<Animator>().Play("FadeInPerson");
        test.gameObject.SetActive(false);
    }

    public void StartFase15()
    {
        screen3.GetComponent<Animator>().Play("FadeInPerson2");
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fase15";
        gameObject.GetComponent<AudioSource>().Stop();
        screen3.GetComponent<AudioSource>().Play();
        screen1.GetComponent<Animator>().Play("FadeInPerson");
        test.gameObject.SetActive(false);
    }

    public void StartFaseEsteira()
    {
        screen2.GetComponent<Animator>().Play("FadeOut2");
        levelName = "Fabrica_reciclagem_05";
        SceneManager.LoadScene(levelName);
        test.gameObject.SetActive(false);
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
