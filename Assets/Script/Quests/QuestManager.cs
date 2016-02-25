using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour {

    public List<Quest> quests;
	public List<Quest> copyQuests;
    void Start()
    {
        if (GameObject.FindObjectOfType<QuestManager>() != this)
        {
            Debug.Log("Trovato altro Quest manager");
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

		copiaQuests ();
    }

	private void copiaQuests(){
		for (int i=0; i<quests.Count; i++) {
			copyQuests.Add((Quest)quests[i].Clone());
		}
	}

	public void addQuest(Quest q){
		copyQuests.Add (q);
	}

    public void Completa(string condizione)
    {
        /*Obiettivo o = new Obiettivo(quests[0].obiettivi[0]);
        o.completato = true;
        Debug.Log("Quest: " + quests[0].obiettivi[0].completato);
        Debug.Log("Obiettivo: " + o.completato);*/
        List<Quest> questDaRimuovere = new List<Quest>(); 
        foreach(Quest q in copyQuests)
        {
                Debug.Log("Controllo " + q.getTitolo());
                if (q.completaObiettivo(condizione))
                {
                    Debug.Log("Completata missione " + q.getTitolo());
                    questDaRimuovere.Add(q);
                    //copyQuests.Remove(q);
                }
        }
        foreach(Quest q in questDaRimuovere)
        {
            copyQuests.Remove(q);
        }
    }
}
