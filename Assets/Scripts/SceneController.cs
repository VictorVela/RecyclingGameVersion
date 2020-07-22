using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ALGORITIMO GERADOR DE CENAS ALEATORIAS
public class SceneController : MonoBehaviour
{
    public GameObject[] scenes; // PREFABS DAS CENAS
    public GameObject nextScenes; // POSICAO PARA INICIAR NOVA CENA

    public GameObject[] trashs;
    public GameObject instancia;
    public GameObject instancia2;
    public List<Coin> trashsToSpawn;

    public List<GameObject> scenesToSpawn; // INSTANCIA DE CENAS CRIADAS

    public bool canGenerateMoreTrahs = true;


    void Start()
    {
        nextScenes = GameObject.Find("StartScenePosition"); // BUSCA NA HIERARQUIA A POSICAO UTILIZADA COMO PONTO INICIAL DE UMA NOVA CENA
        generateScenes();

        generateTrash();
    }

    // GERA UMA QUANTIDADE ESPECIFICA DE CENAS, PARA SEREM UTILIZADAS NO DECORRER DO GAME
    public List<GameObject> generateScenes()  
    {
        int index = 0;
        for (int i = 0; i < scenes.Length * 3; i++) 
        {
            GameObject obj = Instantiate(scenes[index], transform.position, Quaternion.identity);
            obj.SetActive(false);
            scenesToSpawn.Add(obj);

            index++;
            if (index.Equals(scenes.Length))
            {
                index = 0;
            }
        }
        
        return scenesToSpawn;
    }

    // SORTEIA UMA CENA ALEATORIA DA LISTA PARA SER ATIVA NO GAME
    public void AcvateScene()
    {
        int index = Random.Range(0, scenesToSpawn.Count);

        while (true)
        {
            GameObject scene = scenesToSpawn[index];

            if (!scene.gameObject.activeInHierarchy) // VERIFICA SE A CENA JA ESTA SENDO UTILIZADA
            {
                scenesToSpawn[index].gameObject.SetActive(true);
                SceneTrigger sceneTrigger = scenesToSpawn[index].gameObject.GetComponentInChildren<SceneTrigger>();
                sceneTrigger.canGenerate = true;
                testTrashScene2(scene);
                scenesToSpawn[index].transform.position = nextScenes.transform.position;
                //ResetGenerator();
                break;
            }
            else
            {
                index = Random.Range(0, scenesToSpawn.Count);
            }
        }
    }

    private void testTrashScene2(GameObject scene)
    {
        if (scene.layer.Equals(9) || scene.layer.Equals(11))
        {
            if (!instancia)
            {
                instancia = scene;
            }
            else
            {
                instancia2 = scene;
            }
        }
            
    }

    private List<Coin> generateTrash()
    {
        int index = 0;

        for (int i = 0; i < trashs.Length * 3; i++)
        {
            GameObject obj = Instantiate(trashs[index], transform.position, Quaternion.identity);
            obj.SetActive(false);
            trashsToSpawn.Add(obj.GetComponent<Coin>());

            index++;
            if (index.Equals(trashs.Length))
            {
                index = 0;
            }
        }

        return trashsToSpawn;
    }

    public void ActivateTrash()
    {

        GameObject positionTrash = instancia.gameObject.transform.Find("TrashGenerator").gameObject;

        for (int i = 0; i < 5; i++)
        {
            int index = Random.Range(0, 15);

            trashsToSpawn[index].gameObject.SetActive(true);
            trashsToSpawn[index].transform.position = transform.position;
            trashsToSpawn[index].transform.position = new Vector2(positionTrash.transform.position.x, positionTrash.transform.position.y + i * 2);
        }
        instancia = instancia2;
        instancia2 = null;
    }

    public void ResetGenerator()
    {
        foreach (Coin trash in trashsToSpawn)
        {
            trash.flyToCat = false;
            trash.gameObject.SetActive(false);
        }
    }


}
