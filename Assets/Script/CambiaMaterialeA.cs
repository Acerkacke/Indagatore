using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[ExecuteInEditMode]
public class CambiaMaterialeA : MonoBehaviour {

	public Material materialeDaSostituire;

	void OnEnable () {
		if(materialeDaSostituire != null){
			List<Transform> figli = new List<Transform>();
			trovaUltimiFigli(transform,figli);
			foreach(Transform figlio in figli){
				if(figlio.GetComponent<Renderer>()){
					figlio.GetComponent<Renderer>().material = materialeDaSostituire;
				}
			}
		}else{
			Debug.LogError("CambiaMaterialeA - Non hai selezionato un materiale, se non vuoi cambiare materiale basta che togli questo script");
		}
	}

	public void trovaUltimiFigli(Transform tr,List<Transform> linkArray){
		if(tr.childCount > 0){
			for(int i=0;i<tr.childCount;i++){
				trovaUltimiFigli(tr.GetChild(i),linkArray);
			}
		}else{
			linkArray.Add(tr);
		}
	}
}
