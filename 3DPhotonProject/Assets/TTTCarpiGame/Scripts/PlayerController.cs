using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace Monke.TTTCarpi
{
    public class PlayerController : MonoBehaviourPunCallbacks
    {
        [SerializeField] GameObject m_arrowSign;
        [SerializeField] Rigidbody m_rb;
        [SerializeField] BoxCollider m_boxCollider;
        protected PhotonView m_pv;
        protected float xmov, ymov;
        public float m_speed;
        int m_life;

        // Start is called before the first frame update
        void Start()
        {
            m_rb = GetComponent<Rigidbody>();
            m_pv = GetComponent<PhotonView>();
            m_life = 1;
            m_boxCollider.enabled = false;

            if (!m_pv.IsMine)
            {
                m_arrowSign.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(m_pv.IsMine)
            {
                m_arrowSign.SetActive(true);
                xmov = Input.GetAxis("Horizontal");
                ymov = Input.GetAxis("Vertical");
                m_rb.velocity = new Vector3(xmov, 0, ymov) * m_speed;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                m_boxCollider.enabled = true;
            }
            else
            {
                m_boxCollider.enabled = false;
            }

            print("Live: " + m_life);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Player m_otherPlayer = other.GetComponent<PhotonView>().Owner;
                DamageOtherPlayer(m_otherPlayer);

            }
        }

        void DamageOtherPlayer(Player p_otherPlayer)
        {
            if(PhotonNetwork.IsMasterClient)
            {
                Hashtable playerStats = new Hashtable();
                playerStats["damage"] = 1;
                p_otherPlayer.SetCustomProperties(playerStats);
            }
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            if (changedProps.ContainsKey("damage"))
            {
                m_life -=(int)changedProps["damage"];
            }
        }
    }
}

