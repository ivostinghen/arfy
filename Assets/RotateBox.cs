using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBox : MonoBehaviour {

	// Use this for initialization
	public int isLeft;
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.Rotate(Vector3.up * Time.deltaTime * 20 *isLeft);
	}
}
