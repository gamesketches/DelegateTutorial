using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private delegate void PlayerAction();
	private delegate int PlayerCalculation(float input);
	private delegate void PlayerObjectInteraction(GameObject obj);

	PlayerAction currentUpdateFunction;
	PlayerCalculation playerInteraction;
	PlayerObjectInteraction objectInteraction;

	// Use this for initialization
	void Start () {
		currentUpdateFunction = BasicMovement;
		playerInteraction = GimmeTwo;
		objectInteraction = DoNothing;
	}

	void BasicMovement() {
		int speed = 2;
		transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
	}
	
	// Update is called once per frame
	void Update () {
		currentUpdateFunction();
		if(Input.GetKeyDown(KeyCode.Space)){
			playerInteraction(transform.position.x);
		}
		if(Input.GetKeyDown(KeyCode.C)) {
			objectInteraction = ChangeColor;
		}
		if(Input.GetKeyDown(KeyCode.V)) {
			objectInteraction = DrawChangeColor;
		}
		else if(Input.GetKeyDown(KeyCode.B)) {
			objectInteraction = DoNothing;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		objectInteraction(other.gameObject);
	}



	void FastMovement() {
		int speed = 4;
		transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
	}

	int BasicFloor(float input) {
		Debug.Log(Mathf.Floor(input));
		return Mathf.FloorToInt(input);
	}

	int GimmeTwo(float input) {
		return 2;
	}

	void DoNothing(GameObject obj) {
		Debug.Log("lmao");
	}

	void ChangeColor(GameObject obj) {
		obj.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
	}

	void DrawChangeColor(GameObject obj) {
		playerInteraction = obj.GetComponent<INTERACT>().ChangeColor;
	}
}
