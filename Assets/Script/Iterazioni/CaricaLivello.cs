using UnityEngine;
using System.Collections;

public class CaricaLivello : Iterazione{

	public int livello = -1;
	private FadePanel fp;

	void Start(){
		fp = GameObject.FindObjectOfType<FadePanel>();
	}

	public override void Azione(){
		if(livello >= 0){
			fp.StartFade();
			Debug.Log("Completato fade");
			Application.LoadLevel(livello);
		}
	}
}
