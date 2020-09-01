using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public GameObject sceneController;
    private SceneController obj;
    public bool canGenerate;
    

    void Start()
    {
        sceneController = GameObject.Find("SceneController");
        obj = sceneController.GetComponent<SceneController>();
        canGenerate = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && canGenerate)
        {
            //print(collision.transform.position.x);
            obj.AcvateScene();
            canGenerate = false;
        }
        if (collision.gameObject.name.Equals("Girl") && canGenerate)
        {
            //print(collision.transform.position.x);
            obj.AcvateScene();
            canGenerate = false;
        }
    }
}
