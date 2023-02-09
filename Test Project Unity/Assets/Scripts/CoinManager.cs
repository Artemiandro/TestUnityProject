using System;
using UnityEngine;

namespace Coin
{
    [Serializable]
    public class CoinManager
    {
        public Transform m_SpawnPoint;
        [HideInInspector] public GameObject m_Instance;


        public void Reset()
        {
            m_Instance.transform.position = m_SpawnPoint.position;
            m_Instance.transform.rotation = m_SpawnPoint.rotation;

            m_Instance.SetActive(false);
            m_Instance.SetActive(true);
        }

    }
}
