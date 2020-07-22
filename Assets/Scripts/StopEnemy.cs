using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopEnemy : MonoBehaviour
{
    public GameObject enemy;
    private Rigidbody2D enemyRB;
    private Animator enemyAn;

    private bool canIgnorePlayer;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = enemy.GetComponent<Rigidbody2D>();
        enemyAn = enemy.GetComponent<Animator>();

        canIgnorePlayer = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            enemyRB.constraints = RigidbodyConstraints2D.FreezeAll;
            enemyRB.constraints = RigidbodyConstraints2D.None;
            enemyRB.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            enemyAn.Play("Enemy_Iddle");

            //canIgnorePlayer = true;
        }
        
        /*
        if (collision.gameObject.name.Equals("Player") && canIgnorePlayer)
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }*/
    }
}
