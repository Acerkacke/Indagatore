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
    public float minIntensita;
    private float maxIntensitaLocal;
	private bool haTuonato;
    public bool puoLampare;
    private float nextLampo;
    public float tempoTraLampi;

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
		maxIntensitaLocal = Random.Range (0.5f,maxIntensita+0.10f);
	}
	
	void Update () {

        if (!puoLampare)
        {
            if(Time.time > nextLampo)
            {
                puoLampare = true;
            }
        }

        if (lampaDaSolo)
        {
            if (puoLampare)
            {
                if (!hasToLamp)
                {
                    if (Random.Range(0, 500) == 275)
                    {
                        Lampa();
                    }
                }
            }
        }

        if (lampa)
        {
            if (puoLampare)
            {
                Lampa();
                lampa = false;
            }
        }
        if (hasToLamp)
        {
            Lampeggia();
        }
	}

    void calcolaNuovoLampo()
    {
        puoLampare = false;
        nextLampo = Time.time + tempoTraLampi;
    }

    void Lampeggia()
    {
        if (isGoUp)
        {
            intensita += variazione;
            Assegna();
			if(intensita >= maxIntensitaLocal)
            {
				if(!haTuonato){
	                audioSource.clip = audios[Random.Range(0, audios.Count)];
	                audioSource.Play();
                    haTuonato = true;
                }
                calcolaNuovoLampo();
                isGoUp = false;
            }
        }
        else
        {
            intensita -= variazione;
            Assegna();
            if (intensita >= 0.4)
            {
                if (Random.Range(0, 100) >= 76)
                {
                    isGoUp = true;
					randomMaxIntensita();
                }
            }
            if(intensita <= minIntensita)
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
