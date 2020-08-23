using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllerNEW : MonoBehaviour
{
    public GameObject[] scenes; // PREFABS DAS CENAS
    public GameObject nextScenes; // POSICAO PARA INICIAR NOVA CENA
    public GameObject baseScene; // 

    public GameObject[] trashs;
    private GameObject instancia;
    private GameObject instancia2;
    public Vector3 scenePositionBkp;
    //public GameObject baseScene;
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
        //scenePositionBkp = new Vector3(4.1f, 0, 0);

        while (true)
        {
            GameObject scene = scenesToSpawn[index];

            if (!scene.gameObject.activeInHierarchy) // VERIFICA SE A CENA JA ESTA SENDO UTILIZADA
            {
                scenesToSpawn[index].gameObject.SetActive(true);
                SceneTrigger sceneTrigger = scenesToSpawn[index].gameObject.GetComponentInChildren<SceneTrigger>();
                sceneTrigger.canGenerate = true;
                testTrashScene2(scene);
                if (scenePositionBkp.x != 0 && !gameObject.scene.name.Equals("Fase01"))
                {
                    scenesToSpawn[index].transform.position = scenePositionBkp;
                }
                else
                {
                    scenesToSpawn[index].transform.position = new Vector3(baseScene.transform.position.x + 25.927f, baseScene.transform.position.y, baseScene.transform.position.z);
                }

                //scenePositionBkp = scene.transform;
                scenePositionBkp = new Vector3(scene.transform.position.x + 29.10f, scene.transform.position.y, scene.transform.position.z);
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
        int cont = Random.Range(3, 6);

        for (int i = 0; i < cont; i++)
        {
            int index = Random.Range(0, trashsToSpawn.Count - 1);

            while (true)
            {
                if (!trashsToSpawn[index].gameObject.activeInHierarchy) // VERIFICA SE A CENA JA ESTA SENDO UTILIZADA
                {
                    trashsToSpawn[index].gameObject.SetActive(true);
                    trashsToSpawn[index].transform.position = transform.position;
                    trashsToSpawn[index].transform.position = new Vector2(positionTrash.transform.position.x, positionTrash.transform.position.y + i * 2);
                    break;
                }
                else
                {
                    index = Random.Range(0, trashsToSpawn.Count - 1);
                }
            }
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
