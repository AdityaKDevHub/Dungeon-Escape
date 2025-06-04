using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    AudioManager audioManager;
	public GameObject shopPanel;
	public int currentSelectedItem;
	public int currentItemCost;
	private Player _player;

    private void Start() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
    	if (other.tag == "Player") {
    		_player = other.GetComponent<Player>();

    		if (_player != null) {
    			UIManager.Instance.OpenShop(_player.diamonds);
    		}

    		shopPanel.SetActive(true);
    	}
    }

    private void OnTriggerExit2D(Collider2D other) {
    	if (other.tag == "Player") {
    		shopPanel.SetActive(false);
    	}
    }

    public void SelectItem(int item) {
    	switch(item) {
    		case 0:
    			UIManager.Instance.UpdateShopSelection(93);
    			currentSelectedItem = 0;
    			currentItemCost = 100;
                audioManager.PlaySFX(audioManager.ShopSelectionSFX);
    			break;
    		case 1:
    			UIManager.Instance.UpdateShopSelection(7);
    			currentSelectedItem = 1;
    			currentItemCost = 150;
                audioManager.PlaySFX(audioManager.ShopSelectionSFX);
    			break;
    		case 2:
    			UIManager.Instance.UpdateShopSelection(-88);
    			currentSelectedItem = 2;
    			currentItemCost = 200;
                audioManager.PlaySFX(audioManager.ShopSelectionSFX);
    			break;
    	}
    }

    public void BuyItem() {
    	if (_player.diamonds >= currentItemCost) {
            switch (currentSelectedItem) {
                case 0:
                    _player.Fire();
                    break;
                case 1:
                    _player.BoF();
                    break;
                case 2:
                    _player.hasKey = true;
                    break;
            }

    		_player.diamonds -= currentItemCost;
            audioManager.PlaySFX(audioManager.ItemCollectionSFX);
            UIManager.Instance.UpdateGemCount(_player.diamonds);
    		shopPanel.SetActive(false);
    	} else {
    		shopPanel.SetActive(false);
    	}
    }
}
