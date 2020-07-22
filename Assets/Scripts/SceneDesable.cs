using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDesable : MonoBehaviour
{
    private GameObject trashTrigger;
    private GameObject enemyTrigger;
    private GameObject scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("DesableSceneTrigger"))
        {
            scene = collision.transform.parent.gameObject;
            if(scene.layer.Equals(9))
            {
                trashTrigger = scene.gameObject.transform.Find("TrashTrigger").gameObject;
                if (trashTrigger)
                {
                    resetTrashTriggers();
                }
            }
            else if (scene.layer.Equals(10))
            {
                enemyTrigger = scene.gameObject.transform.Find("EnemyTrigger").gameObject;
                if (enemyTrigger)
                {
                    resetEnemyTriggers();
                    resetEnemy();
                }
            }
            else if (scene.layer.Equals(11))
            {
                trashTrigger = scene.gameObject.transform.Find("TrashTrigger").gameObject;
                enemyTrigger = scene.gameObject.transform.Find("EnemyTrigger").gameObject;

                if (trashTrigger && enemyTrigger)
                {
                    resetTrashTriggers();
                    resetEnemyTriggers();
                    resetEnemy();
                }
            }

            collision.transform.parent.gameObject.SetActive(false);
        }           
    }

    void resetTrashTriggers()
    {     
        TrashTrigger trigger = trashTrigger.GetComponent<TrashTrigger>();
        trigger.ResetTrigger();
    }

    //Called when Button is clicked
    void resetEnemyTriggers()
    {
       EnemyTriguer trigger = enemyTrigger.GetComponent<EnemyTriguer>();
       trigger.ResetTrigger();
    }

    void resetEnemy()
    {
        GameObject enemy = scene.gameObject.transform.Find("Enemy").gameObject;
        Rigidbody2D rigidbody2D = enemy.GetComponent<Rigidbody2D>();
        Transform enemyStartPosition = scene.gameObject.transform.Find("EnemyStartPosition");

        rigidbody2D.constraints = RigidbodyConstraints2D.None;
        enemy.transform.localPosition = enemyStartPosition.localPosition;
        enemy.transform.rotation = enemyStartPosition.rotation;
        enemy.transform.localScale = enemyStartPosition.localScale;
    }
}
