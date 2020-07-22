using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Animator animator;

    public float input;
    public float sensibility = 3;
    public bool pressing;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (pressing)
        {
            input += Time.deltaTime * sensibility;
            animator.Play("ButtonPressing");
        }
        else
        {
            input -= Time.deltaTime * sensibility;
            animator.Play("Default");
        }

        input = Mathf.Clamp(input, 0, 1);
    }

    public void Press()
    {
        animator.Play("ButtonPressing");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressing = false;
    }
}
