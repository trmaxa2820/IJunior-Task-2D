using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject);
            player.AddCoin();
            player.Action();
        }
    }
}
