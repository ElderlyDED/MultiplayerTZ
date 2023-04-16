using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviourPunCallbacks
{
    [SerializeField] Text _winnerText;
    [SerializeField] Text _winnerCoinText;
    [SerializeField] Animation _popAnim;
    bool _used;
    
    [PunRPC]
    public void StartPopUp(int coinCount, string playerName)
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        if (_used != true)
        {
            _used = true;
            _winnerText.text = "WINNER " + playerName;
            _winnerCoinText.text = playerName + "pick up: " + coinCount.ToString();
            _popAnim.Play();
        }
    }

    public void MenuBtn()
    {
        PhotonNetwork.LoadLevel("LoadingScene");
    }
}
