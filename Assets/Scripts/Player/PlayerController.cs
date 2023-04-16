using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPunCallbacks, IDamagable, ICoinable
{
    [field: SerializeField] public int CoinCont { get; private set; }
    [field: SerializeField] public int PlayerHP { get; private set; }
    [SerializeField] Text _hpText;
    [SerializeField] Text _nameText;
    Text _resText;
    PopUpController _popUpController;
    GameStatus _gameStatus;

    void Start()
    {
        _nameText.text = photonView.Owner.NickName;
        GameObject.FindGameObjectWithTag("ResultText").
            TryGetComponent(out Text text);
        _resText = text;
        GameObject.FindGameObjectWithTag("PopUp").
            TryGetComponent(out PopUpController pc);
        _popUpController = pc;
        GameObject.FindGameObjectWithTag("GameStatus").
            TryGetComponent(out GameStatus gs);
        _gameStatus = gs;
    }
    
    void Update()
    {
        SetHpText();
        CheckHp();
    }

    void SetHpText()
    {
        _hpText.text = PlayerHP.ToString();
    }

    void CheckHp()
    {
        if (PlayerHP <= 0)
        {
            if (photonView.IsMine)
            {
                _hpText.text = "DIE";
                _gameStatus.SetGameEnd();   
            }
        }
    }

    [PunRPC]
    public void ApplyCoin(int coinCount) => CoinCont++;

    [PunRPC]
    public void ApplyDamage(int damage) => PlayerHP -= damage;
}
