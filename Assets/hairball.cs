using UnityEngine;
using System.Collections;

public class hairball : MonoBehaviour {
	public AudioClip eat_sheep;

	// Use this for initialization
	void Start () {
		StartCoroutine(timer(10));
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator timer(float x){
		//Debug.Log("Activating");
		yield return new WaitForSeconds(x);
		//Debug.Log("Time to deactivate");
		gameObject.SetActive(false);
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Sheep"){
			AudioSource.PlayClipAtPoint(eat_sheep, transform.position);
			col.gameObject.SetActive(false);
		}
	}
}
