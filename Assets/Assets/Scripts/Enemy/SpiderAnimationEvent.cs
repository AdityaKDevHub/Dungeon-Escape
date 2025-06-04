using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEvent : MonoBehaviour
{
	private Spider _spider;

	void Start() {
		_spider = transform.parent.GetComponent<Spider>();
	}

	public void Fire() {
		_spider.Attack();
	}
}
