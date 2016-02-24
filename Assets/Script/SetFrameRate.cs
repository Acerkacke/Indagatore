using UnityEngine;
using System.Collections;

public class SetFrameRate : MonoBehaviour {
	public int frameRate = 30;
	void Awake() {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = frameRate;
	}
}
