using UnityEngine;
using UnityEditor;
using System.Collections;


[System.Serializable]
public class Obiettivo : ScriptableObject{

    public bool completato;
	public string condizione;

	public Obiettivo()
    {
        completato = false;
    }
    public Obiettivo(string condizione)
    {
        if (condizione != null)
        {
            completato = false;
            this.condizione = condizione;
        }
        else
        {
            return;
        }
    }
    public bool Completa(string condizioni)
    {
        if(condizioni == condizione)
        {
            completato = true;
            return true;
        }
        return false;
    }

    public bool eCompletato()
    {
        return completato;
    }

    public string getCondizione()
    {
        return condizione;
    }

    public override string ToString()
    {
        return ("Condizione: " + condizione + ", completato: " + completato);
    }

    public static Obiettivo CreateInstance(string condizione)
    {
        Obiettivo o = (Obiettivo)ScriptableObject.CreateInstance<Obiettivo>();
        o.completato = false;
        o.condizione = condizione;
        return o;
    }
}

[CustomEditor(typeof(Obiettivo))]
public class CustomInspectorObiettivo : Editor{

	public string sel;



	public override void OnInspectorGUI ()
	{
		((Obiettivo)target).condizione = EditorGUILayout.TextField ("Condizione",((Obiettivo)target).condizione);
		((Obiettivo)target).completato = EditorGUILayout.Toggle ("Completato",((Obiettivo)target).completato);
	}
}
