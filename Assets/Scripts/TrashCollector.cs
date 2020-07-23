using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ELIMINACAO DO LIXO NAO COLETADO
        if (collision.gameObject.tag.Equals("Trash"))
        {
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.name.Equals("Player"))
        {
            GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
            collision.gameObject.SetActive(false);
            gameController.GameOver();
        }
    }
}
