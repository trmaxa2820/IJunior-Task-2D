using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _amountCoinToWin;
    private bool _isAlive = true;

    public void KillPlayer()
    {
        _isAlive = false;
    }

    public bool IsAlive()
    {
        return _isAlive;
    }

    public void AddCoin()
    {
        _amountCoinToWin++;
    }

    public int AmountCoin()
    {
        return _amountCoinToWin;
    }
}
