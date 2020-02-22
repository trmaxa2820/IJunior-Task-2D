using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour {
	void Update () 
	{
		transform.Rotate (new Vector3 (0f, 0f, 3f));
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.TryGetComponent<Player>(out Player player))
		{
			player.KillPlayer();
		}
	}
}
