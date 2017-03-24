using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTERACT : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int ChangeColor(float input) {
		GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
		return 0;
	}
}
