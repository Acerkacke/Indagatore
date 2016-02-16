using UnityEngine;
using System.Collections;

public class SeguiTarget : MonoBehaviour {

	public Transform target;
	public float tempo = 0.1f;
	private float tempoAttuale;
	void Start(){
		tempoAttuale = 0.01f;
	}

	void Update () {
		if(tempoAttuale < tempo){
			tempoAttuale+=0.01f;
		}
		if(target != null){
			Vector3 velocity = Vector3.zero;
			Vector3 forward = target.forward * 4.5f;
			Vector3 up = target.up * 7.0f;
			Vector3 targetPos = target.position - forward + up;
			transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity,tempoAttuale);
			transform.LookAt (target);
			//transform.rotation = target.rotation;
		}
	}
}
