using UnityEngine;
using System.Collections;
using InControl;

public class DeviceManager : MonoBehaviour {

	[HideInInspector]
	public static InputDevice currentDevice;
	private InControlManager inControlScript;

	// Use this for initialization
	void Start () {
		currentDevice = InputManager.ActiveDevice;
		inControlScript = GetComponent<InControlManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentDevice = InputManager.ActiveDevice;
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
