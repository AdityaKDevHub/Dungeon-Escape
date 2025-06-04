using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	AudioManager audioManager;

	private void Start()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

    public void MenuButton() {
    	audioManager.PlaySFX(audioManager.ShopSelectionSFX);
    	SceneManager.LoadScene("MainMenu");
    } 
}
