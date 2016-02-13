using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

	private float ogniQuantoSposta = 0.20f;
	private float tempoSpostamento = 0.1f;
	private float timer = 0;
	private Vector3 targetPos;
	private List<Vector3> lastPos;
	private MatricePosizioni matricePos;

	void Start () {
		targetPos = transform.position;
		lastPos = new List<Vector3>();
		matricePos = GameObject.FindObjectOfType<MatricePosizioni>();
	}



	void Update () {
		Trasla();
		if(timer >= 0){
			timer -= Time.deltaTime;
		}
		if(timer <= 0 ){
			if(Input.GetKeyDown(KeyCode.RightArrow)){
				setTargetPos(new Vector3(targetPos.x+1,targetPos.y,targetPos.z));
			}
			if(Input.GetKeyDown(KeyCode.LeftArrow)){
				setTargetPos(new Vector3(targetPos.x-1,targetPos.y,targetPos.z));
			}
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				setTargetPos(new Vector3(targetPos.x,targetPos.y,targetPos.z+1));
			}
			if(Input.GetKeyDown(KeyCode.DownArrow)){
				setTargetPos(new Vector3(targetPos.x,targetPos.y,targetPos.z-1));
			}
		}
	}

	void setTargetPos(Vector3 pos){
		if(canIGoThere(pos)){
			targetPos = pos;
			timer = ogniQuantoSposta;
			lastPos.Add(targetPos);
		}else{
			Debug.Log("setTargetPos - Non puoi andare dove vuoi andare, c'è qualcosa in mezzo");
		}
	}

	bool canIGoThere(Vector3 pos){
		int posx = MatricePosizioni.convertiAsseAPos(pos.x);
		int posz = MatricePosizioni.convertiAsseAPos(pos.z);
		return matricePos.eLibero(posx,posz);
	}

	void Trasla(){
		if(transform.position != targetPos){
			transform.position = Vector3.Lerp(transform.position,targetPos,tempoSpostamento);
		}
	}
}
