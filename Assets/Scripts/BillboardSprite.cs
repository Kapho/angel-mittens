using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardSprite : MonoBehaviour {
	public bool upright = false;

	protected void Update() {
		var player = GameObject.FindGameObjectWithTag("Player");
		transform.LookAt(player.transform);
		if(upright) {
			transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
		}
	}
}
