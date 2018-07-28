using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	Vector3 positions = new Vector3(2,0,-2);
	float time;
	public GameObject boatPrefab;
	void Start () {
		
	}
	
	// Update is called once per frame
	// void LateUpdate () {
	// 	time+=Time.deltaTime;
	// 	if(time>4)
	// 	{
	// 		time = 0;
	// 		// Spawn();
	// 	}
	// }

	public void Spawn()
	{
		GameObject boat = Instantiate(boatPrefab, new Vector3(positions[Random.Range(0,3)],-2.28885F,-6), Quaternion.identity);
		boat.transform.parent = GameObject.Find("World").transform;
	}
}
