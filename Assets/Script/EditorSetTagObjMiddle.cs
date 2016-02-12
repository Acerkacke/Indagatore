using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class EditorSetTagObjMiddle : MonoBehaviour {

	public string tagName;

	void Update () {
		if(tagName != null && tagName != ""){
			controllaPosizione();
			//controllaRotazione();
		}
	}

	void controllaPosizione(){
		GameObject[] gos = GameObject.FindGameObjectsWithTag(tagName);
		if(gos.Length > 0){
			foreach(GameObject go in gos){
				float posx = go.transform.position.x;
				float posz = go.transform.position.z;
				float posy = go.transform.position.y;
				if(go.transform.position.x%1 != 0.5){
					posx = Mathf.Sign(go.transform.position.x) * (Mathf.Abs((int)go.transform.position.x) + 0.5f);
				}
				if(go.transform.position.z%1 != 0.5){
					posz = Mathf.Sign(go.transform.position.z) * (Mathf.Abs((int)go.transform.position.z) + 0.5f);
				}
				if(go.transform.position.y%1 != 0){
					posy = Mathf.RoundToInt(go.transform.position.y);
				}
				if(posx != 0 || posz != 0){
					go.transform.position = new Vector3(posx,posy,posz);
				}
			}
		}
	}
}
