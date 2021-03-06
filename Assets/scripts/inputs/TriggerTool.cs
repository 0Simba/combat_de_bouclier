﻿using UnityEngine;
using System.Collections;
using InControl;

public class TriggerTool : IInput {


	public void Update(InputControl _trigger) {
		if (IsPressed) {
			WasPressed = false;
			if (!_trigger.IsPressed) {
				WasReleased = true;
			}
		} else {
			WasReleased = false;
			if (_trigger.IsPressed) {
				WasPressed = true;
			}
		}
		IsPressed = _trigger.IsPressed;
		HasChanged = WasPressed || WasReleased;
		//Debug.Log (IsPressed + " " + WasPressed + " " + WasReleased + " " + _trigger.IsPressed);
	}

	
}
