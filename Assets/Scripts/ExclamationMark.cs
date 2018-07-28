using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationMark : MonoBehaviour {

	void LateUpdate() {
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time*2, 1),  transform.localPosition.z);
    }

}
