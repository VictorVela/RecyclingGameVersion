using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTrigger : MonoBehaviour
{
    public GameObject warningScreen;
    public GameObject timerGO;
    public GameController gameController;
    private Animator animator;
    private CanvasGroup canvasGroup;
    

    // Start is called before the first frame update
    void Start()
    {
        warningScreen = GameObject.Find("WarningScreen");
        timerGO = GameObject.Find("Timer");
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        animator = warningScreen.GetComponent<Animator>();
        canvasGroup = warningScreen.GetComponent<CanvasGroup>();

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
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
            if (timer.warningTime && gameController.canGenerateAlert)
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1;
                gameController.canGenerateAlert = false;
            }
                
        }
    }
}
