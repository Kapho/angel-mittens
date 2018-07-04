using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {
	public GameObject tower;
	public GameObject tower2;
	public GameObject tower3;
	public GameObject spider;
	public GameObject spider2;
	public GameObject centipede;
	public GameObject centipede2;
	public GameObject boss;

	private float time;
	private Dictionary<float, GameObject> spawnList = new Dictionary<float, GameObject>();
	private List<bool> doneSpawning = new List<bool>();
	private int doneSpawningIndex = 0;

	protected void Start() {
/*
262	x3 GIGAPEDE
274	x2 SPIDER I + SPIDER II
289	x2 SPIDER I + SPIDER II
304	x3 SQUID III
330	x3 SQUID II
350	LEVIATHAN
*/
		spawnList.Add(3f, tower);

		spawnList.Add(14f, tower);

		spawnList.Add(19f, tower);

		spawnList.Add(24f, tower);

		spawnList.Add(39f, tower2);
		spawnList.Add(39.1f, spider);

		spawnList.Add(49f, tower);
		spawnList.Add(49.1f, tower2);

		spawnList.Add(49.2f, tower);
		spawnList.Add(49.3f, tower2);

		spawnList.Add(64f, tower);
		spawnList.Add(64.1f, tower2);

		spawnList.Add(79f, tower);
		spawnList.Add(79.1f, tower2);

		spawnList.Add(94f, tower);
		spawnList.Add(94.1f, tower2);

		spawnList.Add(109f, tower2);

		spawnList.Add(117f, centipede);

		spawnList.Add(119f, spider);

		spawnList.Add(134f, tower);
		spawnList.Add(134.1f, tower2);

		spawnList.Add(144f, tower);
		spawnList.Add(144.1f, tower2);

		spawnList.Add(154f, tower);
		spawnList.Add(154.1f, tower2);

		spawnList.Add(164f, tower);
		spawnList.Add(164.1f, tower2);

		spawnList.Add(174f, spider);
		spawnList.Add(174.1f, spider);
		spawnList.Add(174.2f, spider);

		spawnList.Add(177f, centipede);

		spawnList.Add(184f, tower);
		spawnList.Add(184.1f, tower2);

		spawnList.Add(189f, tower);
		spawnList.Add(189.1f, tower2);

		spawnList.Add(194f, tower);
		spawnList.Add(194.1f, tower2);

		spawnList.Add(199f, spider);
		spawnList.Add(199.1f, spider);
		spawnList.Add(199.2f, spider);

		spawnList.Add(229f, tower);
		spawnList.Add(229.1f, tower);
		spawnList.Add(229.2f, tower);
		spawnList.Add(229.3f, tower);
		spawnList.Add(229.4f, tower);
		spawnList.Add(229.5f, tower);

		spawnList.Add(239f, tower2);
		spawnList.Add(239.1f, tower2);
		spawnList.Add(239.2f, tower2);

		spawnList.Add(244f, tower3);


		for(int i = 0; i < spawnList.Count; i++) {
			doneSpawning.Add(false);
		}
	}

	protected void FixedUpdate() {
		time = Mathf.Floor(GameObject.Find("UI/Text").GetComponent<Timer>().get());

		GameObject toSpawn;
		if(spawnList.TryGetValue(time, out toSpawn) && doneSpawningIndex >= 0 && doneSpawningIndex < doneSpawning.Count && !doneSpawning[doneSpawningIndex]) {
			doneSpawning[doneSpawningIndex] = true;
			Invoke("incrementSpawnIndex", 1.0f);
			var trans = transform.GetChild(Random.Range(0, transform.childCount));
			Instantiate(toSpawn, trans.position, trans.rotation);
		}
	}

	private void incrementSpawnIndex() {
		doneSpawningIndex++;
	}
}
