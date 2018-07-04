using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcGen : MonoBehaviour {
	public GameObject floor;
	private List<GameObject> spawnedFloors = new List<GameObject>();

	protected void Start() {
		Vector3 currentPos = transform.position;
		for(int j = 0; j < 250; j++) {
			var pos = chooseNewRelativePosition();
			var newFloor = Instantiate(floor, currentPos + pos, Quaternion.identity);
			currentPos += pos;
			spawnedFloors.Add(newFloor);
		}

		for(int i = 0; i < spawnedFloors.Count; i++) {
			for(int j = 0; j < spawnedFloors.Count; j++) {
				if(spawnedFloors[i].transform.position == spawnedFloors[j].transform.position && spawnedFloors[i] != spawnedFloors[j]) {
					Destroy(spawnedFloors[i]);
					break;
				}
			}
		}
	}

	private Vector3 chooseNewRelativePosition() {
		var dir = Random.Range(0, 4);
		var step = 8;
		Vector3 pos = Vector3.zero;

		if(dir == 0) {
			pos = new Vector3(step, 0, 0);
		} else if(dir == 1) {
			pos = new Vector3(-step, 0, 0);
		} else if(dir == 2) {
			pos = new Vector3(0, 0, step);
		} else if(dir == 3) {
			pos = new Vector3(0, 0, -step);
		}

		return pos;
	}
}
