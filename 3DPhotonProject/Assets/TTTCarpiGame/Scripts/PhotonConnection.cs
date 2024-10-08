using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PhotonConnection : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField m_newField;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public void OnVSButton()
    {
        
        JoinOrCreateRoom(); //ayuda de luigi
        PhotonNetwork.LoadLevel("Gameplay");

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("SalaPredeterminada",newRoomInfo(),null);
    }

    void JoinOrCreateRoom()
    {
        PhotonNetwork.NickName = m_newField.text;
    }

    RoomOptions newRoomInfo()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;

        return roomOptions;
    }

    public override void OnJoinedRoom()
    {
        print("Se entro al room");
        
    }

}
