using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Rest_Score : MonoBehaviour
{
    public int numeroFase = 85;
    public int pontuacaoFase = 300;

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


    public void OnSendScore()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Score score = new Score();
        score.aluno = data.id_unico;
        score.fase = numeroFase;
        score.pontuacao = pontuacaoFase;
        score.ano = data.ano;
        score.escola = data.escola;

        jsonEncode = JsonUtility.ToJson(score);
        Debug.Log(score.escola);
        

        StartCoroutine(ScorePostRequest(jsonEncode));

    }


    //HTTP API
    IEnumerator ScorePostRequest(string my_json)
    {

        {
            using (UnityWebRequest www = UnityWebRequest.Put(postScoreURL, my_json))
            {
                www.method = UnityWebRequest.kHttpVerbPOST;
                www.SetRequestHeader("Content-Type", "application/json");
                www.SetRequestHeader("Accept", "application/json");

                Debug.Log("Requisição de score enviada com sucesso");

                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                    Debug.Log(my_json);
                    Debug.Log("Tivemos um problema no servidor");
                }
                else
                {
                    RequestRespond requestRespond = new RequestRespond();
                    string resposta = www.downloadHandler.text;
                    requestRespond = JsonUtility.FromJson<RequestRespond>(resposta);

                    if (requestRespond.status == 200)
                    {
                        Debug.Log("Score enviado com sucesso");
                    }
                    else
                    {
                        Debug.Log(requestRespond.status);
                    }
                }

                
            }
        }
    }
    private class RequestRespond
    {
        public int status;
       
    }
}
