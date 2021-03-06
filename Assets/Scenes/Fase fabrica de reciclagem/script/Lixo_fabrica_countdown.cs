﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Lixo_fabrica_countdown : MonoBehaviour
{
    //PUBLIC
    public bool fase5 = false;
    public bool fase6 = false;
    public bool fase7 = false;
    public bool fase8 = false;
    public float speed = 30.0f;
    public Sprite lata, jornal, plastico, vidro, organico, entulho;
    
    


    //PRIVATE
    private int nivel;
    private int randomRange;
    private int original;
    private SpriteRenderer rend;
    private Rigidbody2D rb;
    private bool normal = true;
    private bool firstP = false;
    private bool secondP = false;
    private bool seta01 = false;
    private bool destroy = false;

    //AUDIO
    public static AudioClip coinsound;
    static AudioSource audioSrc;

    //CLASS LIXO
    public class UnicLixo
    {
        public Sprite resultadoLixo;
    }

    // Start is called before the first frame update
    void Start()
    {
        

        //Identificar fase
        if (fase8)
        {
            nivel = 7;
        }
        if (fase7)
        {
            nivel = 5;
        }
        if (fase6)
        {
            nivel = 4;
        }
        if (fase5)
        {
            nivel = 3;
        }

        //Randomizar lixo
        randomRange = Random.Range(0, nivel);
        rend = GetComponent<SpriteRenderer>();

        if (randomRange == 1)
        {
            lata = Resources.Load<Sprite>("lata");
            rend.sprite = lata;
            original = randomRange;
        }

        if (randomRange == 2)
        {
            jornal = Resources.Load<Sprite>("jornal");
            rend.sprite = jornal;
        }

        if (randomRange == 0)
        {
            plastico = Resources.Load<Sprite>("plastico");
            rend.sprite = plastico;
        }

        if (randomRange == 3)
        {
            vidro = Resources.Load<Sprite>("vidro");
            rend.sprite = vidro;
        }

        if (randomRange == 4)
        {
            organico = Resources.Load<Sprite>("organico");
            rend.sprite = organico;
        }

        if (randomRange == 5)
        {
            entulho = Resources.Load<Sprite>("entulho");
            rend.sprite = entulho;
        }

        if (randomRange == 7)
        {
            entulho = Resources.Load<Sprite>("entulho");
            rend.sprite = entulho;
        }
    }

   

    //Verificar colisão
    private void OnTriggerExit2D(Collider2D collision)
    {
        UnicLixo unicLixoPlastico = new UnicLixo();
        unicLixoPlastico.resultadoLixo = rend.sprite;

        //TESTE COM PLASTICO
        if (collision.tag == "plastico_fab")
        {
            if (unicLixoPlastico.resultadoLixo == plastico)
            {
                fab_score.scoreValue += 5;
                fab_score.playSound();
                destroy = true;
                return;
            }
            else
            {
                //fab_score.GameOver();
                perderPonto();
            }
            destroy = true;
            return;

        }

        //TESTE COM METAL
        if (collision.tag == "metal_fab")
        {
            if (rend.sprite == lata)
            {
                fab_score.scoreValue += 5;
                fab_score.playSound();
                destroy = true;
            }
            else
            {
                //fab_score.GameOver();
                perderPonto();
            }
            destroy = true;
        }

        //TESTE COM PAPEL
        if (collision.tag == "papel_fab")
        {
            if (rend.sprite == jornal)
            {
                fab_score.scoreValue += 5;
                fab_score.playSound();
                destroy = true;
            }
            else
            {
                //fab_score.GameOver();
                perderPonto();
            }
            destroy = true;
        }

        //TESTE COM VIDRO
        if (collision.tag == "vidro_fab")
        {
            if (rend.sprite == vidro)
            {
                fab_score.scoreValue += 5;
                fab_score.playSound();
                destroy = true;
            }
            else
            {
                //fab_score.GameOver();
                perderPonto();
            }
            destroy = true;
        }

        //TESTE COM ORGANICO
        if (collision.tag == "organico_fab")
        {
            if (rend.sprite == organico)
            {
                fab_score.scoreValue += 5;
                fab_score.playSound();
                destroy = true;
            }
            else
            {
                //fab_score.GameOver();
                perderPonto();
            }
            destroy = true;
        }

        //TESTE COM ENTULHO
        if (collision.tag == "FinalPoint")
        {
            if (rend.sprite == entulho)
            {
                fab_score.scoreValue += 5;
                fab_score.playSound();
                destroy = true;
            }
            else
            {
                //fab_score.GameOver();
                perderPonto();
            }
            destroy = true;
        }

    }

    public void perderPonto()
    {
        fab_score.scoreValue -= 5;
        if(fab_score.scoreValue < 0)
        {
            fab_score.scoreValue = 0;
        }
    }

    //rotas de colisão e direcionamento 
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "FirstPoint")
        {
            normal = false;
            firstP = true;
        }

        if (collision.tag == "SecondPoint")
        {
            normal = false;
            firstP = false;
            secondP = true;
        }

        //seta 01
        if (collision.tag == "Seta")
        {
            seta01 = true;
        }

    }

    //destruir lixo
    public void DestroyLixo()
    {
        Destroy(this.gameObject);
    }

    // First point
    public void FistPoint()
    {
        firstP = true;
    }

    // Scond point
    public void SecondPoint()
    {
        secondP = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (normal == true)
        {
            rb = this.GetComponent<Rigidbody2D>();
            // rb.velocity = new Vector2(-speed, 0);
            rb.velocity = new Vector2(-speed, 0);
        }

        if (firstP == true)
        {
            rb = this.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, speed);
        }

        if (secondP == true)
        {
            rb = this.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(speed, 0);
        }

        // seta01
        if (seta01 == true)
        {
            rb = this.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, speed);
        }

        if (destroy == true)
        {
            DestroyLixo();
        }
    }
}
