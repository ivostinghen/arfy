using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {

	
	
	IEnumerator Start () {
		Vector3 scale;
		Vector3 pos;
		for(int i=0; i<60; i++)
		{
			scale = transform.localScale;
			pos = transform.position;
			pos.y+=0.02F;
			// scale.x += 0.02F;
			scale.y += 0.04F;
			// scale.z += 0.02F;
			transform.position = pos;
			transform.localScale = scale;
			yield return new WaitForSeconds(0.1F);	
		}
		
	}

	public IEnumerator Close()
	{
		Vector3 scale;
		Vector3 pos;
		for(int i=0; i<15; i++)
		{
			scale = transform.localScale;
			pos = transform.position;
			pos.y-=0.08F;
			// scale.x += 0.02F;
			scale.y -= 0.16F;
			// scale.z += 0.02F;
			transform.position = pos;
			transform.localScale = scale;
			yield return new WaitForSeconds(0.1F);	
		}
		
	}
	
	
}
