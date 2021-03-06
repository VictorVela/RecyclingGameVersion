﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerLivre : MonoBehaviour
{
    public float offsetX = 3f;
    public float smooth = 0.1f;

    public float limitedUp = 2f;
    public float limitedDown = 0f;
    public float limitedLeft = 0f;
    public float limitedRight = 100f;

    private Transform player;
    public Player boy;
    public Player girl;
    private float playerX;
    private float playerY;


    // Start is called before the first frame update
    void Start()
    {
        if (PersonSelect.selectedPerson.Equals("Girl"))
        {
            player = girl.transform;
        }
        else if (PersonSelect.selectedPerson.Equals("Boy") && !gameObject.scene.name.Equals("Fase02"))
        {
            player = boy.transform;
        }
        else if (PersonSelect.selectedPerson.Equals("Boy") && gameObject.scene.name.Equals("Fase02"))
        {
            player = boy.transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            playerX = Mathf.Clamp(player.position.x + offsetX, limitedLeft, limitedRight);
            playerY = Mathf.Clamp(player.position.y, limitedDown, limitedUp);

            transform.position = Vector3.Lerp(transform.position, new Vector3(playerX, playerY, transform.position.z), smooth);
        }
    }
}
