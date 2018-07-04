using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnTouch : MonoBehaviour {
	public int damage = 1;

	protected void OnTriggerEnter(Collider col) {
		if(col.tag == "Player") {
			var me = GetComponentInParent<Identity>().gameObject;
			col.GetComponent<Identity>().takeDamage(damage, me);
		}
	}
}
