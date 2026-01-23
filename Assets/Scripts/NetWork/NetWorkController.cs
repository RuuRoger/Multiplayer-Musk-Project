using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Assets.Scripts.NetWork
{
    public class NetWorkController : MonoBehaviourPunCallbacks
    {
        // ================================================== PUBLIC METHODS ==================================================
        public override void OnConnectedToMaster() //Not Custom
        {
            PhotonNetwork.JoinOrCreateRoom("Adventure", new RoomOptions {MaxPlayers = 2}, null);
        }

        // ================================================== PRIVATE METHODS ==================================================
        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}