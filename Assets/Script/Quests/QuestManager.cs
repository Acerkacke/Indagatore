using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour {

    public List<Quest> quests = new List<Quest>();

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
    }

    public void Completa(string condizione)
    {
        foreach(Quest q in quests)
        {
            Debug.Log("Controllo " + q.getTitolo());
            if (q.completaObiettivo(condizione))
            {
                Debug.Log("Completata missione " + q.getTitolo());
                quests.Remove(q);
            }
        }
    }
}
