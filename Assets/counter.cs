using UnityEngine;
using System.Collections;

public class counter : MonoBehaviour {
	public int stars = 0;
	public int sheep =0;
	private int maxStars = 4;
	static private int best = 0;
	bool baa = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		GUI.color = Color.black;

		if (stars < maxStars){
			GUI.Label (new Rect(850,850, 200, 20),
			           "Number of Sheep spawned: " + sheep + ".");
			GUI.Label (new Rect(1050,850, 300, 20),
			           "Number of Stars collected: " + stars + "/" + maxStars + ".");
		}else{
			if (sheep < best || best == 0){
				best = sheep;
			}
			GUI.Label (new Rect(850,850, 200, 20),
			           "Hooray you collected all " + maxStars + " stars!");
			GUI.Label (new Rect(1050,850, 300, 20),
			           "You spawned " + sheep + " Sheep!");
			if (GUI.Button(new Rect(1650,850, 150, 20), "Play Again?")){
				Application.LoadLevel("fox");
			}
		}
		if( best > 0){
			GUI.Label (new Rect(1550,850, 100, 20),
			           "Best Score: " + best + " Sheep!");
		}
		if (baa){
			if (GUI.Button(new Rect(30,25, 155, 20), "I can't take it! Mute Baa!")){
				baa = !baa;
			}
		}else{
			if (GUI.Button(new Rect(30,25, 80, 20), "More Baa!")){
				baa = !baa;
			}
		}
	}

	public void countSheep(int x){
		sheep = sheep + x;
	}

	public void countStars(int x){
		stars = stars + x;
	}

	public bool hasWon(){
		return (stars == maxStars );
	}

	public bool CanBaa(){
		return baa;
	}

}
