﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float offsetX = 3f;
    public float offsetY = 2f;
    public float smooth = 0.1f;

    public float limitedUp = 2f;
    public float limitedDown = 0f;
    public float limitedLeft = -8f;
    public float limitedRight = 100f;

    private Transform player;
    public Player playerObj;
    public Player boy;
    public Player girl;
    private float playerX;
    private float playerY;

    // Start is called before the first frame update
    void Start()
    {
        /*player = FindObjectOfType<Player>().transform;
        playerObj = player.GetComponent<Player>();*/

        /*if (PersonSelect.selectedPerson.Equals("Girl") && gameObject.scene.name.Equals("Fase04"))
        {
            playerObj = GameObject.Find("Girl").GetComponent<Player>();
        }*/

        if (PersonSelect.selectedPerson.Equals("Girl"))        
        {
            playerObj = girl;
            player = girl.transform;
        }
        else if (PersonSelect.selectedPerson.Equals("Boy") && !gameObject.scene.name.Equals("Fase02"))
        {
            playerObj = boy;
            player = boy.transform;
        }
        else if (PersonSelect.selectedPerson.Equals("Boy") && gameObject.scene.name.Equals("Fase02"))
        {
            playerObj = boy;
            player = boy.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (player != null)
        {   
            /*if (PersonSelect.selectedPerson.Equals("Girl") && gameObject.scene.name.Equals("Fase04") && playerObj.name.Equals("Player") ||
                PersonSelect.selectedPerson.Equals("Girl") && gameObject.scene.name.Equals("Fase09") && playerObj.name.Equals("Player"))
            {
                playerObj = GameObject.Find("Girl").GetComponent<Player>();
            }*/

            limitedLeft = playerObj.bkpCamera;

            playerX = Mathf.Clamp(player.position.x + offsetX, limitedLeft, limitedRight);
            playerY = Mathf.Clamp(player.position.y, limitedDown, limitedUp);

            transform.position = Vector3.Lerp(transform.position, new Vector3(playerX, playerY, transform.position.z), smooth);
        }
        else
        {
            player = FindObjectOfType<Player>().transform;
            playerObj = player.GetComponent<Player>();
        }

        /*if (player != null)
        {

            limitedLeft = playerObj.bkpCamera;
                      
            playerX = Mathf.Clamp(player.position.x + offsetX, limitedLeft, limitedRight);
            playerY = Mathf.Clamp(player.position.y, limitedDown, limitedUp);

            
            transform.position = Vector3.Lerp(transform.position, new Vector3(playerX, player.position.y + offsetY, transform.position.z), smooth);
        }*/

    }
}
