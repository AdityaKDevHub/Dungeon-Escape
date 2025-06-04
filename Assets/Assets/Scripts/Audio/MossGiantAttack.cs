using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiantAttack : MonoBehaviour
{
	AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Attack()
    {
        audioManager.PlaySFX(audioManager.GiantAttackSFX);
    }
}
