using UnityEngine;
using System.Collections;

public class PosScena : MonoBehaviour {

    public string lastPos;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
}
