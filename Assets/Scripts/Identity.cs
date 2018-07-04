using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Identity : MonoBehaviour {
	public GameObject gem;
	public GameObject blooddrop;
	public int health = 5;
	public int healthMax = 5;
	public bool dropGem = false;
	private SpriteRenderer sprite;
	private Color initialColor;

	protected void Start() {
		sprite = transform.Find("sprite").GetComponent<SpriteRenderer>();
		initialColor = sprite.color;
	}

	public void takeDamage(int damage, GameObject attacker) {
		health = Mathf.Clamp(health-damage, 0, healthMax);
		sprite.color = Color.red;
		var bd = Instantiate(blooddrop, transform.position, transform.rotation);
		bd.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere * 450f);
		Invoke("resetColor", 0.1f);
		if(health == 0) {
			if(gameObject.tag == "Player") {
				Time.timeScale = 0.1f;
				gameObject.GetComponentInChildren<PlayerWeapon>().gameObject.SetActive(false);
				gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
				Invoke("gotoGameover", 0.2f);
			} else {
				if(dropGem) {
					Instantiate(gem, transform.position, transform.rotation);
				}
				Destroy(gameObject);
			}
		}
	}

	private void gotoGameover() {
		SceneManager.LoadScene("Survival");
		Time.timeScale = 1.0f;
	}

	private void resetColor() {
		sprite.color = initialColor;
	}
}
