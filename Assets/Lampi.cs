using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lampi : MonoBehaviour {

    public bool lampaDaSolo;
    public bool lampa;
    private bool hasToLamp;
    private bool isGoUp;
    private Light luce;
    public float intensita;
    public float variazione = 0.1f;
    public List<AudioClip> audios = new List<AudioClip>();
    private AudioSource audioSource;
	public float maxIntensita;
	private float maxIntensitaLocal;
	private bool haTuonato;

	void Start () {
        hasToLamp = false;
        luce = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
        intensita = luce.intensity;
	}

    public void Lampa()
    {
        hasToLamp = true;
        isGoUp = true;
		randomMaxIntensita ();
		haTuonato = false;
    }

	private void randomMaxIntensita(){
		maxIntensitaLocal = Random.Range (0,maxIntensita+0.10f);
	}
	
	void Update () {

        if (lampaDaSolo)
        {
            if(Random.Range(0,500) == 275)
            {
                Lampa();
            }
        }

        if (lampa)
        {
            Lampa();
            lampa = false;
        }
        if (hasToLamp)
        {
            Lampeggia();
        }
	}

    void Lampeggia()
    {
        if (isGoUp)
        {
            intensita += variazione;
            //variazione += 0.05f;
            Assegna();
			if(intensita >= maxIntensitaLocal)
            {
				if(!haTuonato){
	                audioSource.clip = audios[Random.Range(0, audios.Count)];
	                audioSource.Play();
				}
                isGoUp = false;
            }
        }
        else
        {
            //variazione -= 0.05f;
            intensita -= variazione;
            Assegna();
            if (intensita >= 0.4)
            {
                if (Random.Range(0, 100) >= 80)
                {
                    isGoUp = true;
					randomMaxIntensita();
                }
            }
            if(intensita <= 0.05)
            {
                hasToLamp = false;
            }
        }
    }

    void Assegna()
    {
        luce.intensity = intensita;
    }
}
