using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Quest : ScriptableObject
{

    protected string titolo;
    protected string descrizione;
    protected Obiettivo[] obiettivi;
    protected bool completata;

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
        Debug.Log("Beh io ho " + obiettivi.Length + " obiettivi");
        for (int i = 0; i < obiettivi.Length; i++)
        {
            if (obiettivi[i].Completa(condizione))
            {
                Debug.Log("Hai completato l'obiettivo " + obiettivi[i].getCondizione());
                if(getUncompletedObiettivi().Length <= 0)
                {
                    Debug.Log("Hai anche completato tutta la quest!");
                    completata = true;
                    return true;
                }
                else
                {
                    Debug.Log("Ti mancano " + getUncompletedObiettivi().Length + " obiettivi");
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
}