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
			StartCoroutine(Carica(2));
		}
	}

	IEnumerator Carica(float quanto) {
		yield return new WaitForSeconds(quanto);

        Application.LoadLevel(livello);
	}
}
