using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	private float duration;
	private float intensity;
	private float decrease;
	private Vector3 initialPosition;

	protected void Start() {
		initialPosition = transform.localPosition;
	}

	protected void Update() {
		if(duration > 0) {
			transform.localPosition += Random.insideUnitSphere * intensity;
			duration -= decrease;
			if(duration <= 0) {
				duration = 0;
				transform.localPosition = initialPosition;
			}
		}
	}

	public void shake(float duration, float intensity, float decrease) {
		this.duration = duration;
		this.intensity = intensity;
		this.decrease = decrease;
	}
}
