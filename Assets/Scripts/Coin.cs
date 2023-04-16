using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController pc))
        {
                pc.photonView.RPC(nameof(pc.ApplyCoin), RpcTarget.All, 1);
                PhotonNetwork.Destroy(gameObject);
        }           
    }
}
