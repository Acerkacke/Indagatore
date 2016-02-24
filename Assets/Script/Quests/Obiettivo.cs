using UnityEngine;
using System.Collections;


[System.Serializable]
public class Obiettivo : ScriptableObject{

    protected bool completato;
    protected string condizione;

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
