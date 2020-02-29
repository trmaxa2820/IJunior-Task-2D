using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private UnityEvent _changedCoin = new UnityEvent();
    private int _amountCoinToWin;
    private bool _isAlive = true;

    public bool IsAlive => _isAlive;
    public event UnityAction ChangedCoin
    {
        add => _changedCoin.AddListener(value);
        remove => _changedCoin.RemoveListener(value);
    }

    public void KillPlayer()
    {
        _isAlive = false;
    }

    public void AddCoin()
    {
        _amountCoinToWin++;
        _changedCoin?.Invoke();
    }

    public int AmountCoin()
    {
        return _amountCoinToWin;
    }
}
