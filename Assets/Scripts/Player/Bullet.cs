using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviourPunCallbacks
{
    [SerializeField] int _damage;
    [SerializeField] float _speed;
    [SerializeField] Vector2 _direction;
    Vector3 _minScreen;
    Vector3 _maxScreen;

    void Start()
    {
        Camera cam = Camera.main;
        _minScreen = cam.ViewportToWorldPoint(new Vector2(0, 0));
        _maxScreen = cam.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        transform.Translate(_direction.normalized * Time.deltaTime * _speed);
        CheckToDestroy();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController pc))
        {
            if (photonView.IsMine)
                return;
            else
            {
                pc.photonView.RPC(nameof(pc.ApplyDamage), RpcTarget.All, _damage);
                PhotonNetwork.Destroy(gameObject);
            }
                
        }
    }

    public void SetDirection(Vector2 dir)
    {
        _direction = dir;
    }

    void CheckToDestroy()
    {
        if (transform.position.x > _maxScreen.x || transform.position.x < _minScreen.x)
           PhotonNetwork.Destroy(gameObject);
        if (transform.position.y > _maxScreen.y || transform.position.y < _minScreen.y)
            PhotonNetwork.Destroy(gameObject);
    }
}
