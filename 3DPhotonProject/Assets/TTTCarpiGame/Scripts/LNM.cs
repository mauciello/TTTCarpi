using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LNM : MonoBehaviourPunCallbacks
{
    public static LNM instance;
    PhotonView m_PV;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(instance);
        }

        m_PV = GetComponent<PhotonView>();

    }

    public void disconnectFromCurrentRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print("Entro nuevo player: " + newPlayer.NickName);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        print("Salio el player: " + otherPlayer.NickName);

    }
}
