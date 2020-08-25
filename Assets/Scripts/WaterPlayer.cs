using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Boy")) 
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }

        if (collision.gameObject.name.Equals("Player"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
            collision.gameObject.GetComponent<Rigidbody2D>().mass = 1.7f;
        }
        if (collision.gameObject.name.Equals("Girl"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
            collision.gameObject.GetComponent<Rigidbody2D>().mass = 1.7f;
        }
    }
}
