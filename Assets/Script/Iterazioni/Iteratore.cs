using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Iteratore : MonoBehaviour {

	public List<Iterazione> iterazioni = new List<Iterazione>();

	public void Attiva(){
		Debug.Log("Attivato");
		foreach(Iterazione iter in iterazioni){
			iter.Azione();
		}
	}

	public void Elenca(){
		foreach(Iterazione iter in iterazioni){
			Debug.Log(iter);
		}
	}
}