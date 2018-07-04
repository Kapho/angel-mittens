using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {
	public GameObject projectile;
	private Transform muzzlePoint;
	private int damage = 1;
	private int projectileCount = 1;
	private bool canFire = true;
	private float fireTime = 0.1f;
	private float muzzleVelocity = 2000f;
	private float spread = 1.5f;
	private float lastFire;
	private bool lerpingUp = true;
	private Vector3 initialPosition;
	private Color handColor = new Color(63, 0, 0, 255);

	protected void Start() {
		muzzlePoint = transform.Find("muzzlePoint");
		initialPosition = transform.localPosition;
		InvokeRepeating("switchLerpDirection", 0, 0.25f);
	}

	protected void Update() {
		if(Input.GetMouseButton(0)) {
			fire();
		}

		if(Input.GetKeyDown(KeyCode.Q)) {
			levelUp();
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

		var sprite = transform.Find("sprite").GetComponent<SpriteRenderer>();
		sprite.color = Color.Lerp(sprite.color, handColor, 0.1f);
	}

	public void levelUp() {
		Debug.Log("DING DING DING!");
		projectileCount++;
		Time.timeScale = 0.75f / projectileCount;
		handColor = new Color(63 * projectileCount, 0, 0, 255);
		Invoke("resetTimeScale", 0.25f);
	}

	private void fire() {
		if(!canFire) {
			return;
		}

		Camera.main.GetComponent<CameraShake>().shake(2.0f, 0.1f * projectileCount, 1.0f);
		transform.localPosition += Random.insideUnitSphere * 0.1f;
		canFire = false;
		lastFire = Time.time;
		Invoke("resetCanFire", fireTime);

		for(int i = 0; i < projectileCount; i++) {
			var proj = Instantiate(projectile, muzzlePoint.position, muzzlePoint.rotation);
			proj.transform.Rotate(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread));
			proj.GetComponent<Rigidbody>().AddForce(proj.transform.up * muzzleVelocity);
			proj.GetComponent<Projectile>().owner = GetComponentInParent<Identity>().gameObject;
			proj.GetComponent<Projectile>().damage = damage;
		}
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

	private void resetTimeScale() {
		Time.timeScale = 1.0f;
	}
}
