using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriguer : MonoBehaviour
{
    public GameObject enemy;
    private Rigidbody2D enemyRB;
    private Animator enemyAn;
    private bool canRolling;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = enemy.GetComponent<Rigidbody2D>();
        enemyAn = enemy.GetComponent<Animator>();

        enemyRB.constraints = RigidbodyConstraints2D.None;
        canRolling = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetTrigger()
    {
        canRolling = true;
        enemyAn.Play("Enemy_Iddle");
        //enemyRB.constraints = RigidbodyConstraints2D.None;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && canRolling)
        {
            enemyRB.AddForce(new Vector2(-400, 0));
            enemyAn.Play("Enemy_Rolling");
            canRolling = false;
        }
    }
}
