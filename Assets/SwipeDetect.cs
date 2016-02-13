using UnityEngine;
using System.Collections;

public class SwipeDetect : MonoBehaviour {

	public TouchGesture.GestureSettings GestureSetting;
	private TouchGesture touch;
	private PlayerScript ps;
	void Start()
	{
		ps = GameObject.FindObjectOfType<PlayerScript>();
		touch = new TouchGesture(this.GestureSetting);
		StartCoroutine(touch.CheckHorizontalSwipes(
			onLeftSwipe: () => { onLeftSwipe(); },
			onRightSwipe: () => { onRightSwipe(); },
			onUpSwipe: () => {onUpSwipe();},
			onDownSwipe: () => {onDownSwipe();}
		));
	}

	void onUpSwipe(){
		ps.Spostati(Direzione.Su);
	}

	void onDownSwipe(){
		ps.Spostati(Direzione.Giu);
	}
	
	void onRightSwipe(){
		ps.Spostati(Direzione.Destra);
	}
	
	void onLeftSwipe(){
		ps.Spostati(Direzione.Sinistra);
	}
}
