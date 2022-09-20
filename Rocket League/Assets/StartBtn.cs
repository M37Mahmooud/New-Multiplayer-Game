using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Network.Scene02
{
    public class StartBtn : MonoBehaviourPunCallbacks
    {

        public void StartGame()
        {
            NetworkConnectionManager.Instance.JoinRoom();
        }
        public override void OnJoinedRoom()
        {
            Debug.Log("Joined!");
        }
    }
}