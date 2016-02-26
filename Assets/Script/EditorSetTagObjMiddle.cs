using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class EditorSetTagObjMiddle : MonoBehaviour {

	public string tagName1;
    public string tagName2;

	void Update () {
		if(tagName1 != null && tagName1 != "" && tagName2 != null && tagName2 != "")
        {
			controllaPosizione();
			//controllaRotazione();
		}
	}

	void controllaPosizione(){
		GameObject[] gos1 = GameObject.FindGameObjectsWithTag(tagName1);
        GameObject[] gos2 = GameObject.FindGameObjectsWithTag(tagName2);
        if (gos1.Length > 0){
			foreach(GameObject go in gos1){
				float posx = go.transform.position.x;
				float posz = go.transform.position.z;
				float posy = go.transform.position.y;
				if(go.transform.position.x%1 != 0.5){
					posx = Mathf.Sign(go.transform.position.x) * (Mathf.Abs((int)go.transform.position.x) + 0.5f);
				}
				if(go.transform.position.z%1 != 0.5){
					posz = Mathf.Sign(go.transform.position.z) * (Mathf.Abs((int)go.transform.position.z) + 0.5f);
				}
				if(go.transform.position.y%1 != 0){
					posy = Mathf.RoundToInt(go.transform.position.y);
				}
				if(posx != 0 || posz != 0){
					go.transform.position = new Vector3(posx,posy,posz);
				}
			}
		}
        if (gos2.Length > 0)
        {
            foreach (GameObject go in gos2)
            {
                float posx = go.transform.position.x;
                float posz = go.transform.position.z;
                float posy = go.transform.position.y;
                if (go.transform.position.x % 1 != 0.5)
                {
                    posx = Mathf.Sign(go.transform.position.x) * (Mathf.Abs((int)go.transform.position.x) + 0.5f);
                }
                if (go.transform.position.z % 1 != 0.5)
                {
                    posz = Mathf.Sign(go.transform.position.z) * (Mathf.Abs((int)go.transform.position.z) + 0.5f);
                }
                if (go.transform.position.y % 1 != 0)
                {
                    posy = Mathf.RoundToInt(go.transform.position.y);
                }
                if (posx != 0 || posz != 0)
                {
                    go.transform.position = new Vector3(posx, posy, posz);
                }
            }
        }
    }
}
