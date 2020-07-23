﻿using System.Collections;
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
        sceneControllerGO = GameObject.Find("SceneController");
        sceneController = sceneControllerGO.GetComponent<SceneController>();
    }

    void Update()
    {
        
    }

    public void ResetTrigger()
    {
        trashGenerator.ResetGenerator();
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
    }
}