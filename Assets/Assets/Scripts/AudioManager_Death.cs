using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager_Death : MonoBehaviour
{
	public AudioSource source;

	public AudioClip Menu;

	public void PlaySFX(AudioClip clip) {
		source.PlayOneShot(clip);
	}
}
