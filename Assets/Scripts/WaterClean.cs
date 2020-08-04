using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterClean : MonoBehaviour
{
    public bool canCleanWater = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        canCleanWater = false;
        player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Player>().trashInRiver > 3)
        {
            canCleanWater = true;
        }
        if (canCleanWater)
        {
            CleanWater();
        }
    }

    public void CleanWater()
    {
        gameObject.GetComponent<Animator>().Play("MoveDown");
    }
}
