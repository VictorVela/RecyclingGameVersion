using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Rest_Client : MonoBehaviour
{
    // Variables
    public Text StatusMessage;
    public InputField userToSend;
    public InputField passwordToSend;
    public Text respondText;
    public string jsonEncode;

    public int status;
    public int escola;
    public int id_unico; // vale por aluno
    public string ano;

    readonly string postLoginURL = "https://ciclointegra.com.br/api/jogo/login/";
    

    //criando instancia e já foi testado
    private void Start()
    {   
        StatusMessage.text = "Digite o seu usuário e senha";
    }

    public void OnButtonSendScore()
    {

        if (userToSend.text == string.Empty || passwordToSend.text == string.Empty)
        {
            StatusMessage.text = "Verifique se todos os campos foram  inseridos";
        }
        else
        {
            LoginData loginData = new LoginData();
            loginData.email = userToSend.text;
            loginData.senha = passwordToSend.text;

            jsonEncode = JsonUtility.ToJson(loginData);


            StatusMessage.text = "Enviando dados aguarde...";
            StartCoroutine(LoginPostRequest(jsonEncode));
        }

    }



    IEnumerator LoginPostRequest(string my_json)
    {

        {

            var bytes = System.Text.Encoding.UTF8.GetBytes(my_json);

            using (UnityWebRequest www = UnityWebRequest.Put(postLoginURL, my_json))
            {
                www.method = UnityWebRequest.kHttpVerbPOST;
                www.SetRequestHeader("Content-Type", "application/json");
                www.SetRequestHeader("Accept", "application/json");

                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                    Debug.Log(my_json);
                    StatusMessage.text = "Tivemos um erro no nosso servidor, tente mais tarde";
                }
                else
                {
                    Debug.Log("Form upload complete!");
                    RequestRespond requestRespond = new RequestRespond();
                    string resposta = www.downloadHandler.text;
                    requestRespond = JsonUtility.FromJson<RequestRespond>(resposta);
                    respondText.text = requestRespond.status.ToString();

                    if (requestRespond.status == 200){
                        requestRespond = JsonUtility.FromJson<RequestRespond>(resposta);
                        status = requestRespond.status;
                        escola = requestRespond.escola;
                        id_unico = requestRespond.id_unico;
                        ano = requestRespond.ano;
                        SaveSystem.SavePlayer(this);// momento onde os dados do jogador é salvo
                        StatusMessage.text = "Entrando no jogo...";
                    }
                    else
                    {
                        StatusMessage.text = "Usuário ou senha incorreto";
                    }


                }
            }
        }
    }

    

    public void SendScore(int pontuacao, int fase)
    {
        PlayerData data = SaveSystem.LoadPlayer();

        int aluno = data.id_unico;
        ano = data.ano;
        escola = data.escola;


    }


    //classe de login
    private class LoginData
    {
        public string email;
        public string senha;
    }

    //classe de resposta
    private class RequestRespond
    {
        public int status;
        public int escola;
        public int id_unico;
        public string ano;
    }
}
