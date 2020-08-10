using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver_fab : MonoBehaviour
{
    public static bool GameOver = false;
    public static bool GameIsPaused = false;
    public static bool NewGame = false;
    public GameObject pauseMenuUI;

    private void Update()
    {
        if (GameOver)
        {
            Pause();
        }
        if (NewGame)
        {
            Resume();
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameOver = false;
        NewGame = false;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        //Time.timeScale = 0f;
        GameOver = false;
        //NewGame = true;
    }


    
}
