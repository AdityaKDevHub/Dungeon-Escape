using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

	private Animator _anim;
	private Animator _swordAnimation;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordAnimation = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float move) {
    	_anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool Jumping) {
    	_anim.SetBool("Jumping", Jumping);
    }

    public void Attack() {
    	_anim.SetTrigger("Attack");
    	_swordAnimation.SetTrigger("SwordAnimation");
    }

    public void Death() {
        _anim.SetTrigger("Death");
    }

    public void FireAttack() {
        _anim.SetBool("Fire", true);
    }

    public void Hit() {
        _anim.SetTrigger("Hit");
    }
}
