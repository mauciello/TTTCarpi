using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class UIManagerMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField m_newNickName;
    [SerializeField] TMP_Text errorText;

    PhotonView m_PV;

    private void Start()
    {
        errorText.text = "";
    }

    public void playButton()
    {

        if (m_newNickName.text == "")
        {
            print("Se necesita un nombre");
            errorText.text = "Error: Se necesita un Nickname";
            return;
        }
        PhotonNetwork.NickName = m_newNickName.text;
    }
}
       

