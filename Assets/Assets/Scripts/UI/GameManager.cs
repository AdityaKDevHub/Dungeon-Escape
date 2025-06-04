using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance 
    {
    	get {
    		if (_instance != null) {
    			Debug.Log("Null");
    		}
    		return _instance;
    	}
    }

    public Player player;

    public bool hasKey { get; set; }

    private void Awake() {
    	_instance = this;
    }
}
