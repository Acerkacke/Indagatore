using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class QuestDatabaseManager : EditorWindow {
    
    [MenuItem("Quests/Database Manager")]
    public static void init()
    {
        QuestDatabaseManager window = (QuestDatabaseManager)EditorWindow.CreateInstance(typeof(QuestDatabaseManager));
        window.Show();
    }
    
    string titolo;
    string descrizione;
    int numeroObiettivi = 0;
    List<Obiettivo> obiettivi = new List<Obiettivo>();

    void OnGUI()
    {
        
        titolo = EditorGUILayout.TextField("Titolo",titolo);
        descrizione = EditorGUILayout.TextField("Descrizione", descrizione);
        numeroObiettivi = EditorGUILayout.IntField("NumeroObiettivi", numeroObiettivi);
        for(int i = 0; i < numeroObiettivi; i++)
        {
            if(i > obiettivi.Count-1)
            {
                obiettivi.Add(null);
            }
            obiettivi[i] = EditorGUILayout.ObjectField(obiettivi[i], typeof(Obiettivo)) as Obiettivo;
        }

        if(GUILayout.Button("Aggiungi Quest"))
        {
            //richiesta minima
            if(titolo != null && descrizione != null && numeroObiettivi > 0)
            {
                svuotaEccessi();
                if (obiettivi.Count > 0)
                {
                    Quest q = Quest.CreateInstance(titolo,descrizione,obiettivi.ToArray());
                    AssetDatabase.CreateAsset(q, "Assets/Script/Quests/Quests/Quest_" + titolo + ".asset");
                    AssetDatabase.SaveAssets();
                }
            }
        }
            
    }

    private void svuotaEccessi()
    {
        for(int i = 0; i < obiettivi.Count; i++)
        {
            if(obiettivi[i] == null)
            {
                obiettivi.RemoveAt(i);
            }
        }
    }

}
