using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;

public class Quest : ScriptableObject,ICloneable
{
    public string titolo;
	public string descrizione;
	public Obiettivo[] obiettivi;
	public bool completata;

    public Quest(string titolo,string descrizione,Obiettivo[] obiettivi)
    {
        this.titolo = titolo;
        this.descrizione = descrizione;
        this.obiettivi = obiettivi;
        completata = false;
    }

    public Quest(string titolo, string descrizione, List<Obiettivo> obiettivi)
    {
        this.titolo = titolo;
        this.descrizione = descrizione;
        this.obiettivi = obiettivi.ToArray();
        completata = false;
    }

    public string getDescrizione()
    {
        return descrizione;
    }
    public string getTitolo()
    {
        return titolo;
    }
    public Obiettivo[] getObiettivi()
    {
        return obiettivi;
    }
    public bool isCompletata()
    {
        return completata;
    }
    public Obiettivo getObiettivo(int index)
    {
        return obiettivi[index];
    }
    public bool haObiettivo(Obiettivo obiettivo)
    {
        for(int i = 0; i < obiettivi.Length; i++)
        {
            if (obiettivi[i].Equals(obiettivo))
            {
                return true;
            }
        }
        return false;
    }
    public bool completaObiettivo(string condizione)
    {
        //Debug.Log("Beh io ho " + obiettivi.Length + " obiettivi");
        for (int i = 0; i < obiettivi.Length; i++)
        {
            if (obiettivi[i].Completa(condizione))
            {
                //Debug.Log("Hai completato l'obiettivo " + obiettivi[i].getCondizione());
                if(getUncompletedObiettivi().Length <= 0)
                {
                    //Debug.Log("Hai anche completato tutta la quest!");
                    completata = true;
                    return true;
                }
                else
                {
                    //Debug.Log("Ti mancano " + getUncompletedObiettivi().Length + " obiettivi");
                    return false;
                }
            }
        }
        return false;
    }
    public Obiettivo[] getUncompletedObiettivi()
    {
        List<Obiettivo> obie = new List<Obiettivo>();

        for (int i = 0; i < obiettivi.Length; i++)
        {
            if (!obiettivi[i].eCompletato())
            {
                obie.Add(obiettivi[i]);
            }
        }

        return obie.ToArray();
    }

    public static Quest CreateInstance(string titolo, string descrizione, Obiettivo[] obiettivi)
    {
        Quest q = (Quest)ScriptableObject.CreateInstance<Quest>();
        q.titolo = titolo;
        q.descrizione = descrizione;
        q.obiettivi = obiettivi;
        return q;
    }
	public object Clone(){
        Obiettivo[] oviettivi = ClonaObiettivi(obiettivi);
		Quest q =  new Quest(titolo,descrizione,oviettivi);
		q.name = name + "Clone";
		return q;
	}

    private Obiettivo[] ClonaObiettivi(Obiettivo[] obi)
    {
       List<Obiettivo> obiets = new List<Obiettivo>();
        for(int i = 0; i < obi.Length; i++)
        {
            obiets.Add(new Obiettivo(obi[i]));
        }
        return obiets.ToArray();
    }
}

[CustomEditor(typeof(Quest))]
public class CustomInspectorQuest : Editor{
	
	public string sel;

	public override void OnInspectorGUI ()
	{
		Quest q = ((Quest)target);
		q.titolo = EditorGUILayout.TextField ("Titolo",q.titolo);
		q.descrizione = EditorGUILayout.TextField ("Descrizione",q.descrizione);
		EditorGUILayout.LabelField ("_______________________________________________________________________________________________________________");
		EditorGUILayout.LabelField ("Obiettivi");
		for (int i=0; i<q.obiettivi.Length; i++) {
			Obiettivo o = q.obiettivi[i];
			o.condizione = EditorGUILayout.TextField ((i+1) + " Condizione",o.condizione);
			o.completato = EditorGUILayout.Toggle ("Completato",o.completato);
		}
	}
}