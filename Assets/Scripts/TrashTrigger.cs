using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTrigger : MonoBehaviour
{
    public TrashGenerator trashGenerator;
    private bool canGenerate;

    GameObject sceneControllerGO;
    SceneController sceneController;
    
    void Start()
    {
        canGenerate = true;
        if (!gameObject.scene.name.Equals("Fase02"))
        {
            sceneControllerGO = GameObject.Find("SceneController");
            sceneController = sceneControllerGO.GetComponent<SceneController>();
        }
    }

    void Update()
    {
        
    }

    public void ResetTrigger()
    {
        //trashGenerator.ResetGenerator();
        canGenerate = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && canGenerate) //GATILHO PARA GERAR O LIXO
        {
            //trashGenerator.ActivateMethods();
            sceneController.ActivateTrash();
            canGenerate = false;
        }

        if (collision.gameObject.name.Equals("Boy") && canGenerate || collision.gameObject.name.Equals("Girl") && collision.gameObject.scene.name.Equals("Fase02") && canGenerate) //GATILHO PARA GERAR O LIXO
        {
            trashGenerator.ActivateMethods();
            //sceneController.ActivateTrash();
            canGenerate = false;
        }

        if (collision.gameObject.name.Equals("Girl") && canGenerate && !collision.gameObject.scene.name.Equals("Fase02")) //GATILHO PARA GERAR O LIXO
        {
            sceneController.ActivateTrash();
            //sceneController.ActivateTrash();
            canGenerate = false;
        }
    }
}
