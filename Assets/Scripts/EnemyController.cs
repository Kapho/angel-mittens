using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public GameObject skull;
	public GameObject skull2;
	public GameObject skull3;
	public enum BrainType {
		SPAWNER,
		SWARM,
		CHASE,
	}

	public BrainType brain;
	private int spawned = 0;
	private int spawnCount = 8;

	protected void Start() {
		switch(brain) {
			case BrainType.SPAWNER:
			InvokeRepeating("spawn", 1.0f, 0.4f);
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
			default:
			Debug.Log("unimplemented brain on " + gameObject.name);
			break;
		}
	}

	private void spawn() {
		spawned++;
		var spawnpoint = transform.Find("spawnpoint");
		Instantiate(skull, spawnpoint.position, spawnpoint.rotation);

		if(spawned == spawnCount) {
			CancelInvoke();
		}
	}
}
