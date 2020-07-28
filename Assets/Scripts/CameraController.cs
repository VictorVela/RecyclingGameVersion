using System.Collections;
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
    private Player playerObj;
    private float playerX;
    private float playerY;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        playerObj = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            limitedLeft = playerObj.bkpCamera;

            playerX = Mathf.Clamp(player.position.x + offsetX, limitedLeft, limitedRight);
            playerY = Mathf.Clamp(player.position.y, limitedDown, limitedUp);

            transform.position = Vector3.Lerp(transform.position, new Vector3(playerX, playerY, transform.position.z), smooth);
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
