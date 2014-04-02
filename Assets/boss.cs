using UnityEngine;
using System.Collections;

public class boss : MonoBehaviour {

	public GameObject pinModel;
	public GameObject monModel;
	public GameObject player;
	public counter cam;
	int montime = 40;

	// Use this for initialization
	void Start () {
		//Debug.Log("This script it totally here");
		StartCoroutine(fireball(2));
		StartCoroutine(monsterSpawn(montime));
	}
	
	// Update is called once per frame
	void Update () {

	}

	void shoot() {
		cam.countSheep(1);
		//Debug.Log("Pew");
		// Create arrow at current position
		//Vector3 spawnPosition = new Vector3 (transform.position.x -100, transform.position.y + 100, transform.position.z);
		GameObject pin = (GameObject) Instantiate(pinModel, transform.position, transform.rotation);
		// Create target
		Vector3 target = player.transform.position - pin.transform.position;
		target.Normalize();
		// Rotate by Atan2 of target
		pin.transform.Rotate(Vector3.forward, Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg);
		// Apply velocity (remember right is "forward")
		pin.rigidbody2D.velocity = pin.transform.right * 10;
		
	}

	void shootMon() {
		cam.countSheep(1);
		//Debug.Log("Pew");
		// Create arrow at current position
		//Vector3 spawnPosition = new Vector3 (transform.position.x -100, transform.position.y + 100, transform.position.z);
		GameObject pin = (GameObject) Instantiate(monModel, transform.position, transform.rotation);
		// Create target
		Vector3 target = player.transform.position - pin.transform.position;
		target.Normalize();
		// Rotate by Atan2 of target
		pin.transform.Rotate(Vector3.forward, Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg);
		// Apply velocity (remember right is "forward")
		pin.rigidbody2D.velocity = pin.transform.right * 10;
		
	}

	IEnumerator fireball(float x){

		yield return new WaitForSeconds(x);
		if (!cam.hasWon()){
			shoot();
			StartCoroutine(fireball(2));
		}

	}

	IEnumerator monsterSpawn(float x){
		
		yield return new WaitForSeconds(x);
		if (!cam.hasWon()){
			shootMon();
			StartCoroutine(monsterSpawn(montime));
		}
		
	}



}
