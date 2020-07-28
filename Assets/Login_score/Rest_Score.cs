using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Rest_Score : MonoBehaviour
{
    readonly string postScoreURL = "https://ciclointegra.com.br/api/jogo/pontuacao/";

    public string jsonEncode;
    private class Score
    {
        public int aluno;
        public int fase;
        public int pontuacao;
        public string ano;
        public int escola;
    }

    public void OnSendScore(int fase, int pontuacao)
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Score score = new Score();

        score.aluno = data.id_unico;
        score.fase = fase;
        score.pontuacao = pontuacao;
        score.ano = data.ano;
        score.escola = data.escola;

        jsonEncode = JsonUtility.ToJson(score);

        StartCoroutine(ScorePostRequest(jsonEncode));

    }


    //HTTP API
    IEnumerator ScorePostRequest(string my_json)
    {

        {

            var bytes = System.Text.Encoding.UTF8.GetBytes(my_json);

            using (UnityWebRequest www = UnityWebRequest.Put(postScoreURL, my_json))
            {
                www.method = UnityWebRequest.kHttpVerbPOST;
                www.SetRequestHeader("Content-Type", "application/json");
                www.SetRequestHeader("Accept", "application/json");

                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                    Debug.Log(my_json);                 
                }
                else
                {
                    Debug.Log("Form upload complete!");
                }
            }
        }
    }
}
