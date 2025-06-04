using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance {
    	get {
    		if (_instance == null) {
    			Debug.Log("Error");
    		}
    		return _instance;
    	}
    }

    public Text playerGemCountText;
    public Image selectionImg;
    public Text GemCountText;
    public Image[] healthBars;

    private void Awake() {
        _instance = this;
    }

    public void OpenShop(int gemCount) {
    	playerGemCountText.text = "" + gemCount + "G";
    }

    public void UpdateShopSelection(int yPos) {
    	selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count) {
        GemCountText.text = "" + count + "G";
    }

    public void UpdateLives(int livesRemaining) {
        for(int i = 0; i <= livesRemaining; i++) {
            if (i == livesRemaining) {
                healthBars[i].enabled = false;
            }
        }
    }
}
