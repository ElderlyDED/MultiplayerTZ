using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] int _coinMax;
    [SerializeField] GameObject _coinPref;

    void Start()   
    {
        for (int i = 0; i < _coinMax; i++)
        {
            var _randPos = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));
            PhotonNetwork.InstantiateSceneObject(_coinPref.name, _randPos, Quaternion.identity);
        }
    }
}
