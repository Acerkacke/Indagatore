using UnityEngine;
using System.Collections;

public class MatricePosizioni : MonoBehaviour {

	public GameObject[,] matrice;

	void Start () {
		matrice = new GameObject[20,20];
		AutoCheck();
	}

	private void AutoCheck(){
		GameObject[] autoGameObjects = GameObject.FindGameObjectsWithTag("Obj");
		foreach(GameObject go in autoGameObjects){
			for(int i=0;i<go.transform.childCount;i++){
				GameObject children = go.transform.GetChild(i).gameObject;
				if(children.transform.position.y >= -0.5 && children.transform.position.y < 0.5){
					Vector2? pos = convertiAssiAPosRelativo(children.transform.position);
					if(pos.HasValue){
						//Debug.Log("AutoCheck - Trovato oggetto in pos (" + pos.Value.x + "," + pos.Value.y + "), nome: " + children.name);
						setMatrPos((int)pos.Value.x,(int)pos.Value.y,children);
					}
				}
			}
		}
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
	public bool eLibero(Vector2 posizione){
		int posx = (int)posizione.x;
		int posy = (int)posizione.y;
		if(matrice[posx,posy] != null){
			//se e' un iteratore
			if(matrice[posx,posy].transform.root.GetComponent<Iteratore>()){
				matrice[posx,posy].transform.root.GetComponent<Iteratore>().Attiva();
				return true;
			}else{
				//se e' solo un blocco
				return false;
			}
		}
		return true;
	}

	public bool cambiaMatrice(Vector2 posizione){
		foreach(MatricePosizioni mp in GameObject.FindObjectsOfType<MatricePosizioni>()){
			//if(!mp.gameObject.Equals(gameObject)){
				if(mp.convertiAssiAPosRelativo(posizione).HasValue){
					GameObject.FindObjectOfType<PlayerScript>().matricePos = mp;
					return true;
				}
			//}
		}
		//non ho trovato nessun altra matrice, forse meglio così
		return false;
	}

	public MatricePosizioni trovaMatrice(Vector2 posizione){
		foreach(MatricePosizioni mp in GameObject.FindObjectsOfType<MatricePosizioni>()){
			if(mp.convertiAssiAPosRelativo(posizione).HasValue){
				return mp;
			}
		}
		//non ho trovato nessun altra matrice, forse meglio così
		return null;
	}

	/// <summary>
	/// Converte l'asse a position in matrice.
	/// </summary>
	/// <returns>La posizione nella matrice.</returns>
	/// <param name="asse">Asse.</param>
	/*public static Vector2 convertiAssiAPos(Vector3 assi){
		return new Vector2(Mathf.RoundToInt(assi.x - 0.5f + 10),Mathf.RoundToInt(assi.z - 0.5f + 10));
	}*/

	public Vector2? convertiAssiAPosRelativo(Vector3 assi){
		Vector2? risultato = new Vector2?(new Vector2(Mathf.RoundToInt(assi.x - 0.5f - transform.position.x + 10),Mathf.RoundToInt(assi.z - 0.5f - transform.position.z + 10)));
		if((risultato.Value.x < 0 || risultato.Value.x >= 20) || (risultato.Value.y < 0 || risultato.Value.y >= 20)){
			return new Vector2?();
		}else{
			return risultato;
		}
	}

	public Vector2? convertiAssiAPosRelativo(Vector2 assi){
		Vector2? risultato = new Vector2?(new Vector2(Mathf.RoundToInt(assi.x - 0.5f - transform.position.x + 10),Mathf.RoundToInt(assi.y - 0.5f - transform.position.z + 10)));
		if((risultato.Value.x < 0 || risultato.Value.x >= 20) || (risultato.Value.y < 0 || risultato.Value.y >= 20)){
			return new Vector2?();
		}else{
			return risultato;
		}
	}
}

