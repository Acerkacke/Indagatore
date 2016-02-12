using UnityEngine;
using System.Collections;

public class SeguiTarget : MonoBehaviour {

	public Transform target;
	public float tempo = 0.1f;

	void Update () {
		if(target != null){
			Vector3 velocity = Vector3.zero;
			Vector3 forward = target.forward * 4.5f;
			Vector3 up = target.up * 5.0f;
			Vector3 targetPos = target.position - forward + up;
			transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity,tempo);
			transform.LookAt (target);
			//transform.rotation = target.rotation;
		}
	}
}
