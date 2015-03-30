using System;
using System.Collections;
using UnityEngine;
using InControl;


namespace ComputerProfile
{
	// This custom profile is enabled by adding it to the Custom Profiles list
	// on the InControlManager component, or you can attach it yourself like so:
	// InputManager.AttachDevice( new UnityInputDevice( "KeyboardAndMouseProfile" ) );
	// 
	public class KeyboardAndMouseProfile : UnityInputDeviceProfile
	{
		public KeyboardAndMouseProfile()
		{
			Name = "Keyboard/Mouse";
			Meta = "A keyboard and mouse combination profile.";

			// This profile only works on desktops.
			SupportedPlatforms = new[]
			{
				"Windows",
				"Mac",
				"Linux"
			};

			Sensitivity = 1.0f;
			LowerDeadZone = 0.0f;
			UpperDeadZone = 1.0f;

			ButtonMappings = new[]
			{
				new InputControlMapping
				{
					Handle = "Submit",
					Target = InputControlType.Action1,
					Source = KeyCodeButton( KeyCode.Space )
				},
				new InputControlMapping
				{
					Handle = "Cancel",
					Target = InputControlType.Action2,
					Source = KeyCodeButton( KeyCode.Backspace )
				},
				new InputControlMapping
				{
					Handle = "ToggleGUI",
					Target = InputControlType.Action4,
					Source = KeyCodeButton( KeyCode.Return )
				},
				new InputControlMapping
				{
					Handle = "Rotation",
					Target = InputControlType.LeftBumper,
					Source = KeyCodeButton( KeyCode.C )
				},
				new InputControlMapping
				{
					Handle = "Manual Rotate Right",
					Target = InputControlType.RightBumper,
					Source = KeyCodeButton( KeyCode.V )
				},
				new InputControlMapping
				{
					Handle = "Action",
					Target = InputControlType.Action3,
					Source = KeyCodeButton( KeyCode.X )
				}
			};

			AnalogMappings = new[]
			{
				new InputControlMapping
				{
					Handle = "Move X",
					Target = InputControlType.LeftStickX,
					// KeyCodeAxis splits the two KeyCodes over an axis. The first is negative, the second positive.
					Source = KeyCodeAxis( KeyCode.A, KeyCode.D )
				},
				new InputControlMapping
				{
					Handle = "Move Y",
					Target = InputControlType.LeftStickY,
					// Notes that up is positive in Unity, therefore the order of KeyCodes is down, up.
					Source = KeyCodeAxis( KeyCode.S, KeyCode.W )
				},
				new InputControlMapping
				{
					Handle = "Move X QWERTY",
					Target = InputControlType.LeftStickX,
					// KeyCodeAxis splits the two KeyCodes over an axis. The first is negative, the second positive.
					Source = KeyCodeAxis( KeyCode.Q, KeyCode.D )
				},
				new InputControlMapping
				{
					Handle = "Move Y QWERTY",
					Target = InputControlType.LeftStickY,
					// Notes that up is positive in Unity, therefore the order of KeyCodes is down, up.
					Source = KeyCodeAxis( KeyCode.S, KeyCode.Z )
				},
				new InputControlMapping {
					Handle = "Move X Alternate",
					Target = InputControlType.LeftStickX,
					Source = KeyCodeAxis( KeyCode.LeftArrow, KeyCode.RightArrow )
				},
				new InputControlMapping {
					Handle = "Move Y Alternate",
					Target = InputControlType.LeftStickY,
					Source = KeyCodeAxis( KeyCode.DownArrow, KeyCode.UpArrow )
				}
			};
		}
	}
}

