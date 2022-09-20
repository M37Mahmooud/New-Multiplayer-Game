using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;

namespace GameManager.Spawner
{
    public class CameraFollowing : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Transform[] startPosition;

        private void Start()
        {
            var player = PhotonNetwork.Instantiate(playerPrefab.name, startPosition[Random.Range(0, startPosition.Length)].position, Quaternion.identity);
            virtualCamera.Follow = player.transform.Find("FollowPoint");
            virtualCamera.LookAt = player.transform.Find("FollowPoint");
        }
    }
}