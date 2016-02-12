using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class InamovibileDalPadre : MonoBehaviour {

	private Vector3 posInCuiDeveStare;

	void OnEnable () {
		posInCuiDeveStare = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.hasChanged){
			transform.localPosition = posInCuiDeveStare;
		}
	}
}
