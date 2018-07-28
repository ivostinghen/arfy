using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    
    public float speed;
    public Vector3 rot;

    IEnumerator Start(){
        while(true)
        {
            yield return new WaitForSeconds(.02F);
             transform.Rotate(rot*speed);
        }
    }

	public void SelfDestroy()
	{
	    
	    Destroy(this.gameObject);
	}



   


}