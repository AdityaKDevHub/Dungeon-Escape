using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
	public int Health { get; set; }
	AudioManager audioManager;

	public override void Init() { //Override inherited Init() function.
		base.Init();
		Health = base.health;
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

	public override void Movement() { //Movement code inherited from Enemy.cs
		base.Movement();
	}

	public void Damage() { //Function when hit by Player.
		if (player.FireDagger == false) {
			Health -= 1;
		} else {
			Health -= 3;
		}

		anim.SetTrigger("Hit");
		IsHit = true;
		anim.SetBool("InCombat", true);

		if (Health > 0) {
			audioManager.PlaySFX(audioManager.SkeletonHitSFX);
		}

		if (Health < 1) { //Death Function
			IsDead = true;
			anim.SetTrigger("Death");
			GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
			diamond.GetComponent<Diamonds>().gems = base.gems;
			audioManager.PlaySFX(audioManager.SkeletonDeathSFX);
			audioManager.PlaySFX(audioManager.SkeletonBoneScatterSFX);
		}
	}
}
