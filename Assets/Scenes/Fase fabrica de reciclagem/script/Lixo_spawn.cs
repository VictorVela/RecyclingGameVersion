using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixo_spawn : MonoBehaviour
{
    public GameObject lixoPrefab;
    private float respawnTime = 5.0f;
    private int counterTime = 0;
    private bool wave1 = true;
    private bool wave2 = true;

    // Start is called before the first frame update
    void Start()
    {     
        StartCoroutine(lixoWave1());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(lixoPrefab) as GameObject;
        
    }

    IEnumerator lixoWave1()
    {
        while (wave1)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
            counterTime++;


            if (counterTime == 24)
            {
                wave1 = false;
                respawnTime = 4f;
                StartCoroutine(lixoWave2());
            }
        }
    }

    IEnumerator lixoWave2()
    {
        while (wave2)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
            counterTime++;


            if (counterTime == 12)
            {
                wave2 = false;
                respawnTime = 3f;
                StartCoroutine(lixoWave3());
            }
        }
    }

    IEnumerator lixoWave3()
    {
        while (wave2)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
