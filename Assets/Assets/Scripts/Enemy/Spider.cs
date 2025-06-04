using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
	public GameObject acidEffectPrefab; //Acid Initialisation
	public int Health { get; set; } //Health Property

	AudioManager audioManager;
	
	public override void Init() { //Override inherited Init() function.
		base.Init();
		Health = base.health;
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

	public override void Movement() { //No movement
		//pass
	}

	public void Attack() { //Spit acid
		Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
	}

	public override void Update() {
		//pass
	}

	public void Damage() { //Function when hit by Player.
		IsDead = true;
		anim.SetTrigger("Death");
		GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
		diamond.GetComponent<Diamonds>().gems = base.gems;
		audioManager.PlaySFX(audioManager.SpiderDeathSFX);
	}
}
