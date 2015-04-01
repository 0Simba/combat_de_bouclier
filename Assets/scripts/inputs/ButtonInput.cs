using UnityEngine;
using System.Collections;
using InControl;

public class ButtonInput : IInput {

    public ButtonInput() { }

    public void Update(InputControl[] btns)
    {
        bool wasPressedBefore = IsPressed;
        IsPressed = false;
        WasPressed = false;
        WasReleased = false;
        for (int i = 0; i < btns.Length; i++)
        {
            WasPressed = !wasPressedBefore && (WasPressed || btns[i].WasPressed);
            WasReleased = WasReleased || btns[i].WasReleased;
            IsPressed = IsPressed || btns[i].IsPressed;
        }
        WasReleased = WasReleased && !IsPressed;
        HasChanged = WasPressed || WasReleased;
        
	}

    public void Update(InputControl btn) {
        IsPressed = btn.IsPressed;
        WasPressed = btn.WasPressed;
        WasReleased = btn.WasReleased;
        HasChanged = btn.HasChanged;
        //Debug.Log(IsPressed + " " + WasPressed + "");
    }
}
