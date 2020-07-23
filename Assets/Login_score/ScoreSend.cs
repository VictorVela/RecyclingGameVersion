using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSend : MonoBehaviour
{
    public void SendScore (int pontuacao, int fase)
    {
        PlayerData data = SaveSystem.LoadPlayer();
    }
}
