using UnityEngine;
using System.Collections;

public class Lampeggia : MonoBehaviour {

    public int probabilitaPerMille = 100;
    public float maxIntensity;
    private Light luce;
    private bool devoLampare;
    
	// Use this for initialization
	void Start () {
        if (GetComponent<Light>())
        {
            luce = GetComponent<Light>();
            if (maxIntensity == 0)
            {
                maxIntensity = luce.intensity;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(luce != null)
        {
            if (!devoLampare)
            {
                if (Random.Range(0, 1000) < probabilitaPerMille)
                {
                    devoLampare = true;
                }
            }
            controlloLampi();
        }
	}
    void controlloLampi()
    {
        if (devoLampare)
        {
            if(luce.intensity < 1.5f)
            {
                luce.intensity += 0.25f;
            }
            else
            {
                devoLampare = false;
            }
        }
        else
        {
            if(luce.intensity > 0)
            {
                luce.intensity -= 0.25f;
            }
        }
    }
}
