using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
	private Player player;

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			player = other.GetComponent<Player>();

			if (player != null) {
				Debug.Log("Spiked");
			}
		}
	}
}
