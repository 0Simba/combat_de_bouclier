using UnityEngine;
using System.Collections;
using InControl;

public class DeviceManager : MonoBehaviour {

	[HideInInspector]
	public static InputDevice currentDevice;

	// Use this for initialization
	void Start () {
		currentDevice = InputManager.ActiveDevice;
	}
	
	// Update is called once per frame
	void Update () {
		currentDevice = InputManager.ActiveDevice;
	}
}
