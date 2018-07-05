using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public GameObject spawning;
	public enum BrainType {
		SPAWNER,
		SWARM,
		CHASE,
		SPEW,
	}

	public BrainType brain;
	public int spawnCount = 8;
	private int spawned = 0;
	private Vector3 currentDirection;

	protected void Start() {
		switch(brain) {
			case BrainType.SPAWNER:
			InvokeRepeating("spawn", 1.0f, 0.4f);
			break;
			
			case BrainType.SPEW:
			InvokeRepeating("shoot", 1.0f, 4.0f);
			break;
		}
	}

	protected void Update() {
		var player = GameObject.FindGameObjectWithTag("Player");
		var playerDir = (player.transform.position - transform.position).normalized;

		switch(brain) {
			case BrainType.SPAWNER:
			transform.Translate(-(transform.position - new Vector3(0, transform.position.y, 0).normalized) * 0.00025f);
			break;

			case BrainType.SWARM:
			GetComponent<Rigidbody>().AddForce(playerDir * 10f, ForceMode.Acceleration);
			break;

			case BrainType.CHASE:
			GetComponent<Rigidbody>().AddForce(new Vector3(playerDir.x, 0, playerDir.z) * 1000f);
			break;

			case BrainType.SPEW:
			GetComponent<Rigidbody>().AddForce(new Vector3(playerDir.x, 0, playerDir.z) * 500f);
			break;

			default:
			Debug.Log("unimplemented brain on " + gameObject.name);
			break;
		}
	}

	private void spawn() {
		spawned++;
		var spawnpoint = transform.Find("spawnpoint");
		Instantiate(spawning, spawnpoint.position, spawnpoint.rotation);

		if(spawned == spawnCount) {
			CancelInvoke();
		}
	}

	private void shoot() {
		var player = GameObject.FindGameObjectWithTag("Player");
		var playerDir = (player.transform.position - transform.position).normalized;

		var spawned = Instantiate(spawning, transform.position, transform.rotation);
		spawned.GetComponent<Rigidbody>().AddForce(playerDir * 30f);
	}
}
