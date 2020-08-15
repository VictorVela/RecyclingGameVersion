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

    private string levelName;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Next()
    {
        screen1.GetComponent<Animator>().Play("FadeOut");
        screen2.GetComponent<Animator>().Play("FadeInMore");
    }

    public void Back()
    {
        screen2.GetComponent<Animator>().Play("FadeOutMore");
        screen1.GetComponent<Animator>().Play("FadeIn");
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
        screen3.GetComponent<Animator>().Play("FadeInPerson");
        levelName = "Fase01";
    }

    public void StartFase02()
    {
        //SceneManager.LoadScene("Fase02");
        screen3.GetComponent<Animator>().Play("FadeInPerson");
        levelName = "Fase02";
    }

    public void StartFase03()
    {
        //SceneManager.LoadScene("Fase03");
        screen3.GetComponent<Animator>().Play("FadeInPerson");
        levelName = "Fase03";
    }

    public void StartFase04()
    {
        //SceneManager.LoadScene("Fase04");
        screen3.GetComponent<Animator>().Play("FadeInPerson");
        levelName = "Fase04";
    }
    public void StartFase05()
    {
        //SceneManager.LoadScene("Fase05");
        levelName = "Fabrica_reciclagem_01";
        SceneManager.LoadScene(levelName);
    }
    public void StartFase06()
    {
        //SceneManager.LoadScene("Fase06");
        screen3.GetComponent<Animator>().Play("FadeInPerson");
        levelName = "Fase06";
    }
    
    public void StartFase07()
    {
        //SceneManager.LoadScene("Fase07");
        screen3.GetComponent<Animator>().Play("FadeInPerson");
        levelName = "Fase07";
    }
    public void StartFase08()
    {
        //screen1.GetComponent<Animator>().Play("FadeInPerson");
        levelName = "Fabrica_reciclagem_05";
        SceneManager.LoadScene(levelName);
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
