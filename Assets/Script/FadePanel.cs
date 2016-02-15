using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class FadePanel : MonoBehaviour {

	bool hasToFade = false;
	float currFade;
	Image panel;
	public float maxWaitTime = 105;

	void Start () {
		currFade = 0f;
		panel = GetComponent<Image>();
	}

	void Update () {
		if(hasToFade){
			if(currFade > 0f){
				Fade();
			}
		}else{
			if(currFade < 1f){
				UnFade();
			}
		}
	}

	private void Fade(){
		currFade+=0.05f;
		panel.color = new Color(0,0,0,currFade);
	}

	private void UnFade(){
		currFade-=0.05f;
		panel.color = new Color(0,0,0,currFade);
	}

	public void StartFade(){
		hasToFade = true;
	} 

	public void StopFade(){
		hasToFade = false;
	}
}
