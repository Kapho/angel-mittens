using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public GameObject particle;
	private GameObject spawnedParticle;
	[HideInInspector]
	public int damage;
	[HideInInspector]
	public GameObject owner;
	private float lifetime = 30f;

	protected void Start() {
		Destroy(gameObject, lifetime);
	}

	protected void OnCollisionEnter(Collision col) {
		Destroy(gameObject);
		var identity = col.collider.GetComponent<Identity>();
		if(identity && identity.gameObject != owner) {
			identity.takeDamage(damage, owner);
		}
		
		 Instantiate(particle, transform.position, transform.rotation);
	}
}
