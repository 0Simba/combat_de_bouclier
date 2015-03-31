using UnityEngine;
using System.Collections;
using InControl;

public class DeviceManager : MonoBehaviour {

	[HideInInspector]
	public static InputDevice currentDevice;
	public static InputDevice[] devices;
	private InControlManager inControlScript;

	// Use this for initialization
	void Start () {
		currentDevice = InputManager.ActiveDevice;
		devices[0]       = InputManager.Devices[0];
		devices[1]       = InputManager.Devices[1];
		devices[2]       = InputManager.Devices[2];
		devices[3]       = InputManager.Devices[3];
		inControlScript = GetComponent<InControlManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentDevice = InputManager.ActiveDevice;
		devices[0]       = InputManager.Devices[0];
		devices[1]       = InputManager.Devices[1];
		devices[2]       = InputManager.Devices[2];
		devices[3]       = InputManager.Devices[3];

		if (InputManager.Devices.Count < 4)
		{
			if (inControlScript.customProfiles.Count == 0)
			{
				inControlScript.customProfiles.Insert(0, "ComputerProfile.KeyboardAndMouseProfile");
			}
		}
		else if (InputManager.Devices.Count > 4)
		{
			if (inControlScript.customProfiles[0] != null)
			{
				inControlScript.customProfiles.Remove("0");
			}
		}
	}
}
