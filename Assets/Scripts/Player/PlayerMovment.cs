using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    FixedJoystick _joystick;
    Rigidbody2D _rb2D;
    [SerializeField] float _playerSpeed;
    PhotonView _photonView;
    Vector2 _derection;
    Vector3 _minScreen;
    Vector3 _maxScreen;
    [field: SerializeField] public Vector2 LastDirection { private set; get; }
    void Start()
    {
        GetComponents();
    }

    void Update()
    {
        if (_photonView.IsMine)
        {
            Moving();
            CheckScreenTransform();
        }
       
    }

    void Moving()
    {
        var x = _joystick.Horizontal * _playerSpeed;
        var y = _joystick.Vertical * _playerSpeed;
        _derection = new Vector2(x, y);
        _rb2D.velocity = _derection;

        if (_derection != new Vector2(0, 0))
        {
            LastDirection = _derection;
        }
    }

    void CheckScreenTransform()
    {
        if (transform.position.x > _maxScreen.x || transform.position.x < _minScreen.x)
        {
            _rb2D.velocity = Vector2.zero;
            _rb2D.AddForce(-_derection * 2000f);
        }
        if (transform.position.y > _maxScreen.y || transform.position.y < _minScreen.y)
        {
            _rb2D.velocity = Vector2.zero;
            _rb2D.AddForce(-_derection * 2000f);
        }
            
    }

    void GetComponents()
    {
        GameObject.FindGameObjectWithTag("Joystick").TryGetComponent(out FixedJoystick _fixJoystick);
        _joystick = _fixJoystick;
        TryGetComponent(out Rigidbody2D _rigidbody);
        _rb2D = _rigidbody;
        TryGetComponent(out PhotonView view);
        _photonView = view;
        Camera cam = Camera.main;
        _minScreen = cam.ViewportToWorldPoint(new Vector2(0, 0));
        _maxScreen = cam.ViewportToWorldPoint(new Vector2(1, 1));
    }
}
