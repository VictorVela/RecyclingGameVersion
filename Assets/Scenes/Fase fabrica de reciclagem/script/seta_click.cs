using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
//using Packages.Rider.Editor.UnitTesting;

public class seta_click : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite cima, reto;
    public bool seta = false;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name.Equals("Seta01") && Input.GetKeyDown("a"))
        {
            MudarSeta();
        }
        if(gameObject.name.Equals("Seta02") && Input.GetKeyDown("s"))
        {
            MudarSeta();
        }
        if(gameObject.name.Equals("Seta03") && Input.GetKeyDown("d"))
        {
            MudarSeta();
        }
        if(gameObject.name.Equals("Seta04") && Input.GetKeyDown("f"))
        {
            MudarSeta();
        }
        if(gameObject.name.Equals("Seta05") && Input.GetKeyDown("g"))
        {
            MudarSeta();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Collider>().enabled = false;
    }


    public void MudarSeta()
    {
        // this object was clicked - do something
        
        seta = !seta;

        if (seta)
        {
            cima = Resources.Load<Sprite>("cima");
            rend.sprite = cima;
            transform.gameObject.tag = "Seta";
        }

        if (seta == false)
        {
            reto = Resources.Load<Sprite>("reto");
            rend.sprite = reto;
            transform.gameObject.tag = "reto";
        }
    }
}
