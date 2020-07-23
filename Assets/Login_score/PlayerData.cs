using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int status;
    public int escola;
    public int id_unico;
    public string ano;

    public PlayerData (Rest_Client player)
    {
        status = player.status;
        escola = player.escola;
        id_unico = player.id_unico;
        ano = player.ano;
    }
}
