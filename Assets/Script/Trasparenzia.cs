using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trasparenzia : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		//Debug.Log("Chi e' questo " + other.transform.root.name);
		if(other.transform.root.GetComponent<AutoTrasparente>()){
			//Debug.Log("Attivato");
			other.transform.root.GetComponent<AutoTrasparente>().devoTrans = true;
		}
	}

	void OnTriggerStay(Collider other) {
		//Debug.Log("Chi e' questo " + other.transform.root.name);
		if(other.transform.root.GetComponent<AutoTrasparente>()){
			//Debug.Log("Attivato");
			if(other.transform.root.GetComponent<AutoTrasparente>().devoTrans != true)
			other.transform.root.GetComponent<AutoTrasparente>().devoTrans = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.transform.root.GetComponent<AutoTrasparente>()){
			other.transform.root.GetComponent<AutoTrasparente>().devoTrans = false;
		}
	}
}
