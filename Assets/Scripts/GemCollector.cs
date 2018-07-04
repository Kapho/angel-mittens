using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollector : MonoBehaviour {
	public int gems = 0;

	protected void OnTriggerEnter(Collider col) {
		if(col.GetComponent<Gem>()) {
			gems++;
			Destroy(col.gameObject);

			if(gems == 10 || gems == 30 || gems == 100) {
				GetComponentInParent<PlayerWeapon>().levelUp();
			}
		}
	}
}
