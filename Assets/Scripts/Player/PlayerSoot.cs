using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSoot : MonoBehaviour
{
    [SerializeField] PlayerMovment _playerMovment;
    PhotonView _photonView;
    [SerializeField] PLayerWeapon _weapon;
    [SerializeField] float _offset;
    [SerializeField] Button _attackBtn;

    void Start()
    {
        TryGetComponent(out PlayerMovment playerMovment);
        _playerMovment = playerMovment;
        TryGetComponent(out PhotonView view);
        _photonView = view;
        GameObject.FindGameObjectWithTag("AttackBtn").TryGetComponent(out Button btn);
        _attackBtn = btn;
        _attackBtn.onClick.AddListener(delegate { Shooting(); });
    }
  
    void Update()
    {
        if (_photonView.IsMine)
        {
            RotateWeapon();
            
            if (Input.GetKeyDown(KeyCode.Z))
                Shooting();
        }
            
       
    }

    void RotateWeapon()
    {
        var rotZ = Mathf.Atan2(_playerMovment.LastDirection.x,
            _playerMovment.LastDirection.y) * Mathf.Rad2Deg;
        _weapon.transform.rotation = Quaternion.Euler(0f, 0f, -rotZ + _offset);
    }

    void Shooting()
    {
        _weapon.Shooting(_playerMovment.LastDirection);   
    }
}
