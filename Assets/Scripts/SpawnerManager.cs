using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {
	public GameObject tower;
	private float time;
	private Dictionary<float, GameObject> spawnList = new Dictionary<float, GameObject>();
	private List<bool> doneSpawning = new List<bool>();
	private int doneSpawningIndex = 0;

	protected void Start() {
		spawnList.Add(5f, null);

		for(int i = 0; i < spawnList.Count; i++) {
			doneSpawning.Add(false);
		}
	}

	protected void Update () {
		time = Mathf.Floor(GameObject.Find("UI/Text").GetComponent<Timer>().get());

		GameObject toSpawn;
		if(spawnList.TryGetValue(time, out toSpawn) && doneSpawningIndex >= 0 && doneSpawningIndex < doneSpawning.Count &&!doneSpawning[doneSpawningIndex]) {
			doneSpawning[doneSpawningIndex] = true;
			doneSpawningIndex++;
			Debug.Log("SPIDER TIME");
			//Instantiate(toSpawn, transform.GetChild(Random.Range(0, transform.childCount)));
		}
		
	}
}
