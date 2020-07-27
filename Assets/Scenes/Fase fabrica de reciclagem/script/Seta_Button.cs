using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seta_Button : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite cima, reto;
    public bool seta = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeButtonSprite()
    {
        // this object was clicked - do something
        Debug.Log("Teste");
        Seta_Button seta_Button = new Seta_Button();
        seta_Button.seta = !seta_Button.seta;

        if (seta_Button.seta)
        {
            seta_Button.cima = Resources.Load<Sprite>("cima");
            seta_Button.rend.sprite = seta_Button.cima;
            transform.gameObject.tag = "Seta";
        }

        if (seta_Button.seta == false)
        {
            seta_Button.reto = Resources.Load<Sprite>("reto");
            seta_Button.rend.sprite = seta_Button.reto;
            transform.gameObject.tag = "reto";
        }
    }
}
