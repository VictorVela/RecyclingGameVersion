using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameUI gameStart;
    public GameUI gameOver;
    public MobileButton buttonSucker;
    public MobileButton buttonRun;
    public GameObject MobileControls;
    public GameObject baseScene;
    public Player player;
    public Player player2;
    public Timer timer;
    
    private Canvas canvas;
    public bool canGenerateAlert;


    Vector3[] defaultPos;
    Vector3[] defaultScale;
    Quaternion[] defaultRot;
    Transform[] models;

    // Start is called before the first frame update
    void Start()
    {
        //GameOpen();
        canvas = FindObjectOfType<Canvas>();
        baseScene = GameObject.Find("BaseScene");
        float aux = canvas.transform.localScale.x;
        if (aux < 0.8f)
        {
            MobileControls.SetActive(true);
        }

        //backUpTransform();
        
        canGenerateAlert = true;

        if (PersonSelect.selectedPerson.Equals("Girl"))
        {
            player.gameObject.SetActive(false);
            player2.gameObject.SetActive(true);
        }
        else
        {
            player.gameObject.SetActive(true);
            player2.gameObject.SetActive(false);
        }
        
    }

    public void GameOpen()
    {
        gameStart.Show();
    }

    public void GameStart()
    {
        gameStart.Hide();
        player.SetActive();
        baseScene.SetActive(true);
    }

    public void GameOver()
    {
        print(player.gameObject.scene.name + " sementes: " + player.points);
        gameOver.Show();
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        timer.playerDead = true;
        timer.gameFinished = true;
        GetComponent<AudioSource>().Stop();
        GameObject.Find("SoundTest").GetComponent<AudioSource>().Play();
    }

    public void TimeOver()
    {
        gameOver.Show();
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        timer.playerDead = true;
    }

    public void ToGameRestart()
    {
        gameOver.Hide();
        SceneManager.LoadScene("Menu");
        //resetTransform();
        //resetTrashTriggers();
        //resetEnemyTriggers();
    }

    void backUpTransform()
    {
        //Find GameObjects with Model tag
        GameObject[] tempModels = GameObject.FindGameObjectsWithTag("Enemy");

        //Create pos, scale and rot, Transform array size based on sixe of Objects found
        defaultPos = new Vector3[tempModels.Length];
        defaultScale = new Vector3[tempModels.Length];
        defaultRot = new Quaternion[tempModels.Length];

        models = new Transform[tempModels.Length];

        //Get original the pos, scale and rot of each Object on the transform
        for (int i = 0; i < tempModels.Length; i++)
        {
            models[i] = tempModels[i].GetComponent<Transform>();

            defaultPos[i] = models[i].position;
            defaultScale[i] = models[i].localScale;
            defaultRot[i] = models[i].rotation;
        }
    }

    //Called when Button is clicked
    void resetTransform()
    {
        //Restore the all the original pos, scale and rot  of each GameOBject
        for (int i = 0; i < models.Length; i++)
        {
            models[i].position = defaultPos[i];
            models[i].localScale = defaultScale[i];
            models[i].rotation = defaultRot[i];
        }
    }

    //Called when Button is clicked
    void resetTrashTriggers()
    {
        GameObject[] trashTriggers = GameObject.FindGameObjectsWithTag("TrashTrigger");
        //Restore the all the original pos, scale and rot  of each GameOBject
        foreach(GameObject component in trashTriggers)
        {
            TrashTrigger trigger = component.GetComponent<TrashTrigger>();
            trigger.ResetTrigger();
        }
    }

    //Called when Button is clicked
    void resetEnemyTriggers()
    {
        GameObject[] enemyTriggers = GameObject.FindGameObjectsWithTag("EnemyTrigger");
        //Restore the all the original pos, scale and rot  of each GameOBject
        foreach (GameObject component in enemyTriggers)
        {
            EnemyTriguer trigger = component.GetComponent<EnemyTriguer>();
            trigger.ResetTrigger();
        }
    }

    public void CloseWarnning()
    {
        GameObject warningScreen = GameObject.Find("WarningScreen");
        warningScreen.GetComponent<CanvasGroup>().alpha = 0;
        canGenerateAlert = false;
    }

}
