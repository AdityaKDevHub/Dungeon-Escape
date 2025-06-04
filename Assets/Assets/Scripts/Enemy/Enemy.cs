using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	public GameObject diamondPrefab; //Drop diamonds upon death

	[SerializeField]
	protected int health;
	[SerializeField]
	protected float speed;
	[SerializeField]
	protected int gems;
	[SerializeField]
	protected Transform pointA, pointB; //Target points for waypoint-motion.

	protected Vector3 currentTarget;
	protected Animator anim;
	protected SpriteRenderer sprite;

	protected bool IsHit = false;

	protected Player player;

	protected bool IsDead = false;

	public virtual void Init() { //Initialise Function
		anim = GetComponentInChildren<Animator>();
		sprite = GetComponentInChildren<SpriteRenderer>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	void Start() {
		Init();
	}

	public virtual void Update() { //Update per frame
		if (health < 1) {
			return;
		}

		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false) {
			return;
		}

		if (IsDead == false) {
			Movement(); 
		}
	}

	public virtual void Movement() { //Movement code
		if (currentTarget == pointA.position) { //Flipping the sprite.
    		sprite.flipX = true;
    	} else {
    		sprite.flipX = false;
    	}

		if (transform.position == pointA.position) { //Idle when reached point
			currentTarget = pointB.position;
			anim.SetTrigger("Idle");
		} else if (transform.position == pointB.position) {
			currentTarget = pointA.position;
			anim.SetTrigger("Idle");
		}

		if (IsHit == false) {
			transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime); //Motion
		}

		float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
		if (distance > 2.0f) { //Return to walk if Player > 2 units away
			IsHit = false;
			anim.SetBool("InCombat", false);
		}

		Vector3 direction = player.transform.localPosition - transform.localPosition;
		if (direction.x > 0 && anim.GetBool("InCombat") == true) { //Follow Player's direction when in combat.
			sprite.flipX = false;
		} else if (direction.x < 0 && anim.GetBool("InCombat") == true) {
			sprite.flipX = true;
		}
	}
}
