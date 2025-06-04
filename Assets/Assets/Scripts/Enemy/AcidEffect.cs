using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
	void Start() {
		Destroy(this.gameObject, 2.0f);
	}

    void Update() {
    	StartCoroutine(FireAcid());
    }

    private void OnTriggerEnter2D(Collider2D other) {
    	if (other.tag == "Player") {
    		IDamageable hit = other.GetComponent<IDamageable>();

    		if (hit != null) {
    			hit.Damage();
    			Destroy(this.gameObject);
    		}
    	}
    }

    IEnumerator FireAcid() {
    	yield return new WaitForSeconds(0.2f);
    	transform.Translate(Vector3.left * 6 * Time.deltaTime);
    }
}
