using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

	private float ogniQuantoSposta = 0.20f;
	private float tempoSpostamento = 0.1f;
	private float timer = 0;
	private Vector3 targetPos;
	private List<Vector3> lastPos;
	public MatricePosizioni matricePos;

	void Start () {
		targetPos = transform.position;
		lastPos = new List<Vector3>();
		matricePos = GameObject.FindObjectOfType<MatricePosizioni>().trovaMatrice(transform.position);
	}



	void Update () {
		Trasla();
		if(timer >= 0){
			timer -= Time.deltaTime;
		}
		if(timer <= 0 ){
			if(Input.GetKeyDown(KeyCode.RightArrow)){
				Spostati(Direzione.Destra);
			}
			if(Input.GetKeyDown(KeyCode.LeftArrow)){
				Spostati(Direzione.Sinistra);
			}
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				Spostati(Direzione.Su);
			}
			if(Input.GetKeyDown(KeyCode.DownArrow)){
				Spostati(Direzione.Giu);
			}
		}
	}

	public void Spostati(Direzione dir){
		switch(dir){
		case Direzione.Su:
			setTargetPos(new Vector3(targetPos.x,targetPos.y,targetPos.z+1));
			break;
		case Direzione.Giu:
			setTargetPos(new Vector3(targetPos.x,targetPos.y,targetPos.z-1));
			break;
		case Direzione.Destra:
			setTargetPos(new Vector3(targetPos.x+1,targetPos.y,targetPos.z));
			break;
		case Direzione.Sinistra:
			setTargetPos(new Vector3(targetPos.x-1,targetPos.y,targetPos.z));
			break;
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
		Vector2? posizione = matricePos.convertiAssiAPosRelativo(pos);
		if(posizione.HasValue){
			return matricePos.eLibero(posizione.Value);
		}else{
			MatricePosizioni matr = matricePos.trovaMatrice(pos);
			if(matr != null){
				matricePos = matr;
				Vector2? posizio = matricePos.convertiAssiAPosRelativo(pos);
				return matr.eLibero(posizio.Value);
			}else{
				return false;
			}
		}
	}

	void Trasla(){
		if(transform.position != targetPos){
			transform.position = Vector3.Lerp(transform.position,targetPos,tempoSpostamento);
		}
	}
}

public enum Direzione{
	Su,
	Giu,
	Destra,
	Sinistra
}
