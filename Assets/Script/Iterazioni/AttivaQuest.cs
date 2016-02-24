using UnityEngine;
using System.Collections;

public class AttivaQuest : Iterazione {

    QuestManager qm;

    public string condizione;

    void Start()
    {
        qm = GameObject.FindObjectOfType<QuestManager>();
    }

	public override void Azione()
    {
        if(qm != null)
        {
            Debug.Log("ciao");
            qm.Completa(condizione);
        }
    }
}
