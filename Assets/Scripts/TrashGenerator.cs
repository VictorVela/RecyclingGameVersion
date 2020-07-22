using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashGenerator : MonoBehaviour
{
    public GameObject[] objects;
    public List<Coin> objectsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //generateTrash();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGenerator()
    {
        foreach (Coin trash in objectsToSpawn)
        {
            trash.flyToCat = false;
            trash.gameObject.SetActive(false);
        }
    }

    public void ActivateMethods()
    {
        //generateTrash();
        //ActivateTrash();
    }

    private List<Coin> generateTrash()
      {
        int index = 0;
        
            for (int i = 0; i < objects.Length * 2; i++)
            {
                GameObject obj = Instantiate(objects[index], transform.position, Quaternion.identity);
                obj.SetActive(false);
                objectsToSpawn.Add(obj.GetComponent<Coin>());

                index++;
                if (index.Equals(objects.Length))
                {
                    index = 0;
                }
            }

        return objectsToSpawn;
    }

    private void ActivateTrash()
    {

        for (int i = 0; i < 5; i++)
        {
            int index = Random.Range(0, 6);

             objectsToSpawn[index].gameObject.SetActive(true);
             objectsToSpawn[index].transform.position = transform.position;
             objectsToSpawn[index].transform.position = new Vector2(objectsToSpawn[index].transform.position.x, objectsToSpawn[index].transform.position.y + i * 2);
        }
    }
}
