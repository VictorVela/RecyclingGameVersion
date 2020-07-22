using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTrigger : MonoBehaviour
{
    public GameObject warningScreen;
    public GameObject timerGO;
    private Animator animator;
    private CanvasGroup canvasGroup;
    private bool canGenerate;

    // Start is called before the first frame update
    void Start()
    {
        warningScreen = GameObject.Find("WarningScreen");
        timerGO = GameObject.Find("Timer");

        animator = warningScreen.GetComponent<Animator>();
        canvasGroup = warningScreen.GetComponent<CanvasGroup>();

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canGenerate = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            Timer timer = timerGO.GetComponent<Timer>();
            if (timer.warningTime && canGenerate)
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1;
                canGenerate = false;
            }
                
        }
    }
}
