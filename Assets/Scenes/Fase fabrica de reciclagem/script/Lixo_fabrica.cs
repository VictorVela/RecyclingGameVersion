using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Lixo_fabrica : MonoBehaviour
{
    public float speed = 30.0f;
    public Sprite lata, jornal, plastico, vidro, organico, entulho;
    private SpriteRenderer rend;
    private Rigidbody2D rb;
    private int randomRange;
    private bool normal = true;
    private bool firstP = false;
    private bool secondP = false;
    private bool seta01 = false;
    private bool destroy = false;
    private int original;

    // Start is called before the first frame update
    void Start()
    {

        randomRange = Random.Range(0,2);

        rend = GetComponent<SpriteRenderer>();

        if (randomRange == 0)
        {
            lata = Resources.Load<Sprite>("lata");
            rend.sprite = lata;
            original = randomRange;
        }

        if (randomRange == 1)
        {
            jornal = Resources.Load<Sprite>("jornal");
            rend.sprite = jornal;
        }

        if (randomRange == 2)
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

        if (randomRange == 6)
        {
            entulho = Resources.Load<Sprite>("entulho");
            rend.sprite = entulho;
        }

    }

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

        //Plastico
        if (collision.tag == "plastico_fab")
        {
            Debug.Log("plastico");
            if (randomRange == 2)
            {
                fab_score.scoreValue += 10;
                destroy = true;
            }
            else
            {
                fab_score.GameOver();
            }
            Debug.Log(randomRange);
            destroy = true;

        }

        if (collision.tag == "metal_fab")
        {
            if (randomRange == 0)
            {
                fab_score.scoreValue += 10;
                destroy = true;
            }
            else
            {
              fab_score.GameOver();
            }
            Debug.Log(randomRange);
            destroy = true;

        }

        if (collision.tag == "papel_fab")
        {
            if (randomRange == 1)
            {
                fab_score.scoreValue += 10;
                destroy = true;
            }
            else
            {
                fab_score.GameOver();
            }
            Debug.Log(randomRange);
            destroy = true;

        }

        if (collision.tag == "vidro_fab")
        {
            if (randomRange == 3)
            {
                fab_score.scoreValue += 10;
                destroy = true;
            }
            else
            {
                fab_score.GameOver();
            }
            Debug.Log(randomRange);
            destroy = true;

        }

        if (collision.tag == "organico_fab")
        {
            if (randomRange == 4)
            {
                fab_score.scoreValue += 10;
                destroy = true;
            }
            else
            {
                fab_score.GameOver();
            }
            Debug.Log(randomRange);
            destroy = true;

        }

        if (collision.tag == "FinalPoint")
        {
            if(randomRange == 5 || randomRange == 6)
            {
                fab_score.scoreValue += 10;
                destroy = true;
            }
            else
            {
                fab_score.GameOver();
            }
            Debug.Log(randomRange);
            destroy = true;
        }
    }

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
