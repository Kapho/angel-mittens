using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardSprite : MonoBehaviour {
	public bool upright = false;

	protected void Update() {
		var player = GameObject.FindGameObjectWithTag("Player");
		transform.LookAt(player.transform, transform.forward);
		if(upright) {
			transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
		}
	}
}
