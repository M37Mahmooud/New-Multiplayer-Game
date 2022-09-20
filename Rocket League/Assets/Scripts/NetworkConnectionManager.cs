using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Network
{
    public class NetworkConnectionManager : MonoBehaviourPunCallbacks
    {
        public static NetworkConnectionManager Instance;

        public GameObject selectionModePanel;
        public GameObject offlineModePanel;

        public Button btnSinglePlayer;
        public Text message;

        private void Awake()
        {
            if(Instance == null)
                Instance = this;
            else 
                Destroy(gameObject);
            
            DontDestroyOnLoad(gameObject);

            if(!PhotonNetwork.IsConnected){
                PhotonNetwork.GameVersion = "0.1";
                PhotonNetwork.AutomaticallySyncScene = true;
                PhotonNetwork.ConnectUsingSettings();
                selectionModePanel.SetActive(true);
                offlineModePanel.SetActive(false);
            }
            else{
                selectionModePanel.SetActive(false);
                offlineModePanel.SetActive(true);
                SceneManager.LoadScene("Offline Mode Scene");
            }

        }

        public void JoinRoom()
        {
            PhotonNetwork.LoadLevel("Arena");
        }

        public void OnClickJoinLobby()
        {
            Debug.Log("Join to Lobby!");
            PhotonNetwork.JoinLobby();
        }

        public void OnClickSinglePlayer()
        {
            if(message == null)
                return;
            
            message.gameObject.SetActive(true);
            message.text = "Under Develop!";
            StartCoroutine(Message());
        }

        public void OnClickMultiplayer()
        {
            PhotonNetwork.JoinLobby();
        }

        IEnumerator Message()
        {
            yield return new WaitForSeconds(5);
            message.gameObject.SetActive(false);
        }

        public override void OnJoinedLobby()
        {
            PhotonNetwork.LoadLevel("Lobby Scene");
            Debug.Log("Joined to Lobby!");
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connect to Master!");
        }
    }
}
