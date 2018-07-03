using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public GameObject gem;
	public enum BrainType {
		SPAWNER,
		SWARM,
	}

	public BrainType brain;

	protected void Start() {

	}

	protected void Update() {
		var player = GameObject.FindGameObjectWithTag("Player");

		switch(brain) {
			case BrainType.SPAWNER:
			break;
			case BrainType.SWARM:
			break;
			default:
			Debug.Log("unimplemented brain on " + gameObject.name);
			break;
		}
	}
}
