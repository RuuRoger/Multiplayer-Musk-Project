using System;
using UnityEngine;

namespace Assets.Scripts.NetWork
{
    public class UINetwork : MonoBehaviour
    {
        // ================================================== FIELDS ==================================================
        [SerializeField] private GameObject m_connecitngPanel;

        // ================================================== PUBLIC METHODS ==================================================
        public void LoadingComplete()
        {
            m_connecitngPanel.SetActive(false);
        }
    }
}