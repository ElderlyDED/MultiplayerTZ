using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField _createInput;
    [SerializeField] InputField _joinInput;
    [SerializeField] InputField _nameInput;

    private void Start()
    {
        _nameInput.text = PlayerPrefs.GetString("name");
        PhotonNetwork.NickName = _nameInput.text;
    }

    public void CreateRoom() => PhotonNetwork.CreateRoom(
        _createInput.text, new Photon.Realtime.RoomOptions { MaxPlayers = 2});

    public void JoinRoom() => PhotonNetwork.JoinRoom(_joinInput.text);

    public override void OnJoinedRoom() => PhotonNetwork.LoadLevel("GameScene");

    public void SaveName()
    {
        PlayerPrefs.SetString("name", _nameInput.text);
        PhotonNetwork.NickName = _nameInput.text;
    }
}
