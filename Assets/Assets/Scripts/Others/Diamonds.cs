using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
	public int gems = 20;
    AudioManager audioManager;

    private void Start() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
    	if (other.tag == "Player") {
    		Player player = other.GetComponent<Player>();

    		if (player != null) {
    			player.AddGems(gems);
                audioManager.PlaySFX(audioManager.DiamondCollectSFX);
    			Destroy(this.gameObject);
    		}
    	}
    }
}
