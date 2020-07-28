using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    public GameObject screen1;
    public GameObject screen2;

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

    public void GameStart()
    {
        //SceneManager.LoadScene("Fase01");
    }

    public void StartFase01()
    {
        SceneManager.LoadScene("Fase01");
    }

    public void StartFase02()
    {
        //SceneManager.LoadScene("Fase02");
    }

    public void StartFase03()
    {
        SceneManager.LoadScene("Fase03");
    }

    public void StartFase04()
    {
        SceneManager.LoadScene("Fase04");
    }
    public void StartFase05()
    {
        //SceneManager.LoadScene("Fase05");
    }
    public void StartFase06()
    {
        SceneManager.LoadScene("Fase06");
    }
    
    public void StartFase07()
    {
        SceneManager.LoadScene("Fase07");
    }
}
