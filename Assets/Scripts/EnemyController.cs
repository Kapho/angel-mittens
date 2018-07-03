using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public GameObject gem;
	public enum BrainType {
		SWARM,
	}

	public BrainType brain;
	public bool dropGem = false;

	protected void Start() {

	}

	protected void Update() {
		var player = GameObject.FindGameObjectWithTag("Player");

		switch(brain) {
			case BrainType.SWARM:
			break;
			default:
			Debug.Log("unimplemented brain on " + gameObject.name);
			break;
		}

		if(GetComponent<Identity>().health == 0 && dropGem) {
			Instantiate(gem, transform.position, transform.rotation);
		}
	}
}
