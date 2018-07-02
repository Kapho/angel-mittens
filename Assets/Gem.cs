using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {
	private float rotationSpeed = 12f;
	private float attractionDelay = 2.0f;
	protected void Update() {
		transform.Rotate(0, rotationSpeed, 0);

		var player = GameObject.FindGameObjectWithTag("Player");

		if(Time.time - player.GetComponentInChildren<PlayerWeapon>().getLastFire() >= attractionDelay) {
			var dir = -(transform.position - player.transform.position).normalized;
			GetComponent<Rigidbody>().AddForce(dir * 100f);
		}
	}
}
