using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pause;

    public void LevelsScreen()
    {
        SceneManager.LoadScene("Menu");
        PersonSelect.pause = false;
        pause.gameObject.SetActive(false);
    }

    public void Continue()
    {
        pause.gameObject.SetActive(false);
        PersonSelect.pause = false;
    }

    public void PauseScreen()
    {
        pause.gameObject.SetActive(true);
        PersonSelect.pause = true;
    }
}
