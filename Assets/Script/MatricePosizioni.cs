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
			for(int i=0;i<go.transform.childCount;i++){
				GameObject children = go.transform.GetChild(i).gameObject;
				if(children.transform.position.y == 0){
					int posx = convertiAsseAPos(children.transform.position.x);
					int posz = convertiAsseAPos(children.transform.position.z);
					Debug.Log("AutoCheck - Trovato oggetto in pos (" + posx + "," + posz + "), nome: " + children.name);
					setMatrPos(posx,posz,children);
				}
			}
		}
	}

	void Update () {
	
	}

	private void setMatrPos(int posx, int posz, GameObject go){
		if(matrice[posx,posz] == null){
			matrice[posx,posz] = go;
		}else{
			Debug.LogError("setMatrPos - La posizione (" + posx + "," + posz + ") e' gia' occupata da " + matrice[posx,posz].name + " e vuole essere sostituita da " + go.name +"," +
			               " le loro posizioni sono rispettivamente " + matrice[posx,posz].transform.position + " e " + go.transform.position +",correggi");
		}
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
		return Mathf.RoundToInt(asse - 0.5f + 10);
	}
}
