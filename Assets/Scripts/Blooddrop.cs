using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blooddrop : MonoBehaviour {
	public GameObject Bloodsplat;
	protected void OnCollisionEnter(Collision col) {
		var normal = col.contacts[0].normal;
		var rot = Quaternion.LookRotation(-normal) * Quaternion.Euler(0, 0, Random.rotation.eulerAngles.z);
		Instantiate(Bloodsplat, transform.position, rot);
		Destroy(gameObject);
	}
}
