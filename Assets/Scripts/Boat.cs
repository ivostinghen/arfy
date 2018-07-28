using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

	public float speed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.Translate(Vector3.forward  * Time.deltaTime * speed);
	}
}
