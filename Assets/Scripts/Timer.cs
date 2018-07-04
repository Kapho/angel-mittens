using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	private float lastStart;

	protected void Start() {
		lastStart = Time.time;
	}

	protected void Update() {
		var player = GameObject.FindGameObjectWithTag("Player");
		if(player.GetComponent<Identity>().health > 0) {
			GetComponent<Text>().text = get().ToString();
		}
	}

	public float get() {
		return (Time.time - lastStart);
	}
}
