using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private Animator animator;
    private CanvasGroup canvasGroup;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void Show()
    {
        animator.Play("FadeIn");

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        animator.Play("FadeOut");

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    
}
