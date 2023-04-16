using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] List<Transform> _playerSpawnPoint = new();
    [SerializeField] List<GameObject> _playerVariants = new();
    void Start()
    {
        int i = Array.IndexOf(PhotonNetwork.PlayerList, PhotonNetwork.LocalPlayer);
        var playerAvatar = PhotonNetwork.Instantiate(_playerVariants[i].name, _playerSpawnPoint[i].position, Quaternion.identity);
    }


}
