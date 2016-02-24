using UnityEngine;
using System.Collections;

public class EventiMenu : MonoBehaviour {
    
	void Start () {
	
	}
	
	void Update () {
	
	}

    private void caricaLivelloDiGioco(int livello)
    {
        PlayerPrefs.SetInt("LivelloDesiderato",livello);
        Application.LoadLevel("Caricamento");
    }

}
