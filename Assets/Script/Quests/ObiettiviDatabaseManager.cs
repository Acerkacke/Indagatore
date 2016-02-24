using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class ObiettiviDatabaseManager : EditorWindow
{

    [MenuItem("Quests/Obiettivi Manager")]
    public static void init()
    {
        ObiettiviDatabaseManager window = (ObiettiviDatabaseManager)EditorWindow.CreateInstance(typeof(ObiettiviDatabaseManager));
        window.Show();
    }
    
    string condizione;

    void OnGUI()
    {
        condizione = EditorGUILayout.TextField("Condizione", condizione);

        if (GUILayout.Button("Aggiungi Obiettivo"))
        {
            //richiesta minima
            if (condizione != null)
            {
                Obiettivo o = Obiettivo.CreateInstance(condizione);
                
                AssetDatabase.CreateAsset(o, "Assets/Script/Quests/Obiettivi/Obiettivo_" + condizione + ".asset");
                AssetDatabase.SaveAssets();
            }
        }
    }

}
