using UnityEngine;
using System.Collections;

public class MainPlayer : MonoBehaviour {

    public int deviceIndex = 0;
    public int playerIndex = 0;


	void Start() {
		gameObject.SetActive(DeviceManager.devices [deviceIndex] != null);
	}
}
