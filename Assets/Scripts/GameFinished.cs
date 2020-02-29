using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class GameFinished : MonoBehaviour
{
    private Player _player;
    [SerializeField] private int _amountCounToWin;

    private void Start()
    {
        _player = gameObject.GetComponent<Player>();
        _player.ChangedCoin += Finish;
    }

    private void Finish()
    {
        if(_player.AmountCoin() == _amountCounToWin)
        {
            Debug.Log("Finish");
            _player.ChangedCoin -= Finish;
        }
    }

}
