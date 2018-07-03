using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour {
	protected void OnTriggerEnter(Collider col) {
		var identity = col.GetComponent<Identity>();
		if(identity) {
			identity.takeDamage(identity.healthMax, null);
		} else {
			Destroy(col.gameObject);
		}
	}
}
