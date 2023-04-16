using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerWeapon : MonoBehaviour, IShooting
{
    [SerializeField] Transform _shootPoint;
    [SerializeField] GameObject _bulletPref;
    public void Shooting(Vector2 shootDir)
    {
        var bullet = PhotonNetwork.Instantiate(_bulletPref.name, _shootPoint.position, Quaternion.identity);
        bullet.TryGetComponent(out Bullet bulletScript);
        bulletScript.SetDirection(shootDir);
    }

}
