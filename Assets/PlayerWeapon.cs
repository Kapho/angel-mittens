using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {
	public GameObject projectile;
	private Transform muzzlePoint;
	private int damage = 1;
	private bool canFire = true;
	private float fireTime = 0.1f;
	private float muzzleVelocity = 2000f;
	private float spread = 1.5f;
	private float lastFire;
	private bool lerpingUp = true;
	private Vector3 initialPosition;

	protected void Start() {
		muzzlePoint = transform.Find("muzzlePoint");
		initialPosition = transform.localPosition;
		var bounceTime = 0.25f;
		InvokeRepeating("switchLerpDirection", 0, bounceTime);
	}

	protected void Update() {
		if(Input.GetMouseButton(0)) {
			fire();
		}

		var bounceSpeed = 0.25f;
		var bounceAmount = 0.015f;

		var dest = initialPosition;

		if(GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().Velocity != Vector3.zero) {
			if(lerpingUp) {
				dest.y -= bounceAmount;
				transform.localPosition = Vector3.Lerp(transform.localPosition, dest, bounceSpeed);
			} else {
				dest.y += bounceAmount;
				transform.localPosition = Vector3.Lerp(transform.localPosition, dest, bounceSpeed);
			}
		} else {
			transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition, 0.33f);
		}

		Color.Lerp(GetComponentInChildren<SpriteRenderer>().color, Color.red, 0.33f);
	}

	private void fire() {
		if(!canFire) {
			return;
		}

		canFire = false;
		lastFire = Time.time;
		Invoke("resetCanFire", fireTime);
		var proj = Instantiate(projectile, muzzlePoint.position, muzzlePoint.rotation);
		proj.transform.Rotate(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread));
		proj.GetComponent<Rigidbody>().AddForce(proj.transform.up * muzzleVelocity);
		proj.GetComponent<Projectile>().owner = gameObject;
		proj.GetComponent<Projectile>().damage = damage;
	}

	private void resetCanFire() {
		canFire = true;
	}

	private void switchLerpDirection() {
		lerpingUp = !lerpingUp;
	}

	public float getLastFire() {
		return lastFire;
	}
}
