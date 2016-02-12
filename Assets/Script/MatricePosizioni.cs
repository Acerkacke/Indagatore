using UnityEngine;
using System.Collections;

public class MatricePosizioni : MonoBehaviour {

	public GameObject[,] matrice;

	void Start () {
		matrice = new GameObject[20,20];
		AutoCheck();
	}

	void AutoCheck(){
		GameObject[] autoGameObjects = GameObject.FindGameObjectsWithTag("Obj");
		foreach(GameObject go in autoGameObjects){
			int posx = (int)(go.transform.position.x - 0.5f + 10);
			int posz = (int)(go.transform.position.z - 0.5f + 10);
			Debug.Log("AutoCheck - Trovato oggetto in pos " + posx + "," + posz);
			matrice[posx,posz] = go;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// Controlla se la posizione indicata e' libera o meno.
	/// </summary>
	/// <returns><c>true</c>, se libero, <c>false</c> se occupato da qualcosa.</returns>
	/// <param name="posx">posx</param>
	/// <param name="posy">posy</param>
	public bool eLibero(int posx, int posy){
		if(matrice[posx,posy] != null)
			return false;
		return true;
	}

	/// <summary>
	/// Converte l'asse a position in matrice.
	/// </summary>
	/// <returns>La posizione nella matrice.</returns>
	/// <param name="asse">Asse.</param>
	public static int convertiAsseAPos(float asse){
		return (int)(asse - 0.5f + 10);
	}
}
