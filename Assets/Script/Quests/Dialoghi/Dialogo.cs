using UnityEngine;
using System.Collections;

public class Dialogo : ScriptableObject {

    public string[] frasi;
    public float tempoScrittura = -1;

    public Dialogo CreateInstance(string[] frasi)
    {
        Dialogo d = ScriptableObject.CreateInstance<Dialogo>();
        d.frasi = frasi;
        return d;
    }
	
}
