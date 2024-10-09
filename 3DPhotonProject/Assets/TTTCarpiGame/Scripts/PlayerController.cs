using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

namespace Monke.TTTCarpi
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] GameObject m_arrowSign;
        [SerializeField] Rigidbody m_rb;
        protected PhotonView m_pv;
        protected float xmov, ymov;
        public float m_speed;

        // Start is called before the first frame update
        void Start()
        {
            m_rb = GetComponent<Rigidbody>();
            m_pv = GetComponent<PhotonView>();

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
        }
    }
}

