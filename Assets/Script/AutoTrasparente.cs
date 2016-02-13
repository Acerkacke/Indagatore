using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoTrasparente : MonoBehaviour {

	public bool devoTrans;
	private float trasCurr;
	private float maxTrans = 0.05f;
	private List<Transform> ultimiFigli;

	void Start () {
		trasCurr = 1f;
		devoTrans = false;
		ultimiFigli = new List<Transform>();
		trovaUltimiFigli(transform,ultimiFigli);
	}

	void Update () {
		if(devoTrans){
			if(trasCurr > maxTrans)
				trasparenziati();
		}else{
			if(trasCurr < 1f)
				deTrasparenziati();
		}
	}

	private void trasparenziati(){
		trasCurr -= 0.05f;
		foreach(Transform tr in ultimiFigli){
			Material mat = tr.GetComponent<Renderer>().material;
			mat.color = new Color(mat.color.r,mat.color.g,mat.color.b,trasCurr);

		}
	}
	private void deTrasparenziati(){
		trasCurr += 0.05f;
		foreach(Transform tr in ultimiFigli){
			Material mat = tr.GetComponent<Renderer>().material;
			mat.color = new Color(mat.color.r,mat.color.g,mat.color.b,trasCurr);
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
