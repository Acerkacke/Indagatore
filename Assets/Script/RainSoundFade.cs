using UnityEngine;
using System.Collections;
using DigitalRuby.RainMaker;

public class RainSoundFade : MonoBehaviour {


    public RainScript rainsc;
    private bool hasToFade = false;

	void Start () {
        rainsc = GetComponent<RainScript>();
	}

    void Update()
    {
        if (hasToFade)
        {
            fade();
        }
    }

    private void fade()
    {
        rainsc.RainIntensity -= 0.1f;
    }
	
	public void Fade()
    {
        hasToFade = true;
    }
}
