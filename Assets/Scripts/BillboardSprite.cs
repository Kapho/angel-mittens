using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardSprite : MonoBehaviour {
	protected void Update() {
		var player = GameObject.FindGameObjectWithTag("Player");
		transform.LookAt(player.transform);
	}
}
