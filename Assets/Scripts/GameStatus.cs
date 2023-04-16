using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviourPunCallbacks
{
    [field: SerializeField] public bool GameEnd { get; private set; }

    
    public void SetGameEnd()
    {
        GameEnd = true;
        List<GameObject> pcList = new();
        pcList.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        foreach(GameObject player in pcList)
        {
            if (player.TryGetComponent(out PlayerController playerController))
            {
                if (playerController.PlayerHP > 0)
                {
                    GameObject.FindGameObjectWithTag("PopUp").
                        TryGetComponent(out PopUpController pc);
                    pc.photonView.RPC(nameof(pc.StartPopUp), RpcTarget.All, playerController.CoinCont, playerController.photonView.Owner.NickName);
                }
            }
        }
    }
}
