using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private float ogniQuantoSposta = 0.25f;
	private float tempoSpostamento = 0.05f;
	private float timer = 0;
	private Vector3 targetPos;
	void Start () {
		targetPos = transform.position;
	}



	void Update () {
		Trasla();
		if(timer >= 0){
			timer -= Time.deltaTime;
		}
		if(timer <= 0 ){
			if(Input.GetKeyDown(KeyCode.RightArrow)){
				targetPos = new Vector3(targetPos.x+1,targetPos.y,targetPos.z);
				timer = ogniQuantoSposta;
			}
			if(Input.GetKeyDown(KeyCode.LeftArrow)){
				targetPos = new Vector3(targetPos.x-1,targetPos.y,targetPos.z);
				timer = ogniQuantoSposta;
			}
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				targetPos = new Vector3(targetPos.x,targetPos.y,targetPos.z+1);
				timer = ogniQuantoSposta;
			}
			if(Input.GetKeyDown(KeyCode.DownArrow)){
				targetPos = new Vector3(targetPos.x,targetPos.y,targetPos.z-1);
				timer = ogniQuantoSposta;
			}
		}
	}

	void Trasla(){
		if(transform.position != targetPos){
			Vector3 velocity = Vector3.zero;
			transform.position = Vector3.SmoothDamp(transform.position,targetPos,ref velocity,tempoSpostamento);
		}
	}
}
