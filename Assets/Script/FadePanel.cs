using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class FadePanel : MonoBehaviour {

	private bool hasToFade;
	private float currFade;
	Image panel;
	public float secondi = 1;
	private float deltaAlpha;

	void Start () {
		hasToFade = false;
		panel = GetComponent<Image>();
		currFade = panel.color.a;
		deltaAlpha = (1f/40)/secondi;
	}

	void Update () {
		if(hasToFade){
			if(currFade < 1f){
				Fade();
			}
		}else{
			if(currFade > 0f){
				UnFade();
			}
		}
	}

	private void Fade(){
		currFade+=deltaAlpha;
		panel.color = new Color(0,0,0,currFade);
	}

	private void UnFade(){
		currFade-=deltaAlpha;
		panel.color = new Color(0,0,0,currFade);
	}

	public void StartFade(){
		hasToFade = true;
	} 

	public void StopFade(){
		hasToFade = false;
	}
}
