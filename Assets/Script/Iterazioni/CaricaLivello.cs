using UnityEngine;
using System.Collections;

public class CaricaLivello : Iterazione{

	public int livello = -1;
	private FadePanel fp;
    private RainSoundFade rsf;
    private PlayerScript ps;

	void Start(){
		fp = GameObject.FindObjectOfType<FadePanel>();
        rsf = GameObject.FindObjectOfType<RainSoundFade>();
        ps = GameObject.FindObjectOfType<PlayerScript>();

    }

	public override void Azione(){
		if(livello >= 0){
			fp.StartFade();
            if (rsf != null)
            {
                rsf.Fade();
            }
            ps.enabled = false;
            StartCoroutine(Carica(2));
		}
	}

	IEnumerator Carica(float quanto) {
		yield return new WaitForSeconds(quanto);

        Application.LoadLevel(livello);
	}
}
