using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    //PhotonView m_photonView;
    private void Start()
    {
        //m_photonView = GetComponent<PhotonView>();

        //if (m_photonView.IsMine)
        //{
        //    PhotonNetwork.Instantiate("SpawnPlatforms",transform.position, Quaternion.identity);
        //}

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 randomPosition = spawnPoints[randomIndex].position;

        PhotonNetwork.Instantiate("Player", randomPosition, Quaternion.identity);
        
        
    }
}

