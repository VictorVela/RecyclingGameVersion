using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Fase01");
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
}
