using UnityEngine;
using System.Collections;

public class MatricePosizioni : MonoBehaviour {

	public GameObject[,] matrice;

	void Start () {
		matrice = new GameObject[20,20];
	}

	void AutoCheck(){
		GameObject[] autoGameObjects = GameObject.FindGameObjectsWithTag("Obj");
		foreach(GameObject go in autoGameObjects){

		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
