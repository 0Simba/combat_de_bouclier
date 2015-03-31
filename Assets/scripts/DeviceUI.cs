using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine.UI;

public class DeviceUI : MonoBehaviour {

	public int playerSlot;
	private bool isOk;

	void Update()
	{
		var inputDevice = (InputManager.Devices.Count > playerSlot) ? InputManager.Devices[playerSlot] : null;
		if (inputDevice == null)
		{
			// If no controller exists for this cube, just make it translucent.
			GetComponent<Image>().color = new Color ( 1.0f, 1.0f, 1.0f, 0.2f);
			GetComponentInChildren<Text>().text = "No Controller";
			isOk = false;
		}
		else if (InputManager.Devices[playerSlot] != null)
		{
			if (isOk == false)
			{
				GetComponent<Image>().color = new Color ( 1.0f, 1.0f, 1.0f, 0.6f);
				GetComponentInChildren<Text>().text = inputDevice.Name;
				if (InputManager.Devices[playerSlot].Action1.WasPressed)
				{
					isOk = true;
				}
			}
			if (isOk == true)
			{
				GetComponent<Image>().color = new Color ( 1.0f, 1.0f, 1.0f, 1.0f);
				GetComponentInChildren<Text>().text = "OK !";
				if (InputManager.Devices[playerSlot].Action2.WasPressed)
				{
					isOk = false;
				}
			}
		}
	}
}
